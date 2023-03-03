using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MushroomLauncher : MonoBehaviour
{
    public List<PlayerFunglebehaviour> mushroomAmmoTypes;
    public List<MeshRenderer> ammoSlotRenderers;
    public ammoAudioPair[] audioPairs;
    public int currentAmmoIndex;
    public Transform firePoint;
    public Transform cameraTrans;
    public BulletBehaviour bullet;
    public float bulletFireForce = 30;
    public float maxGunLookAhead = 10;
    public LayerMask mask;
    public Animator gunAnimator;
    public bool canSwitchAmmoType = true;
    private FMODUnity.EventReference ammoFireAudioAddress;
    public FMODUnity.EventReference defaultAmmoFireAudioAddress;
    public FMODUnity.EventReference unableChangeSound;
    public static MushroomLauncher instance;
    public int bulletCap = 20;
    public List<GameObject> activeBullets; //bullets active in the scene

    [Header("UI Element")]
    public Image wheel;

    private void OnEnable()
    {
        gunAnimator.SetTrigger("AmmoPickUp");
        UpdateAmmoVisuals();
        UpdateSoundAdresses();
        ControlsManager.instance.controls.GunConrols.Fire.performed += Shoot;
        ControlsManager.instance.controls.GunConrols.CycleAmmo.performed += CycleAmmo;
    }
    private void OnDisable()
    {
        ControlsManager.instance.controls.GunConrols.Fire.performed -= Shoot;
        ControlsManager.instance.controls.GunConrols.CycleAmmo.performed -= CycleAmmo;
    }

    private void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        instance = this;
        gameObject.SetActive(false);
    }
    

    private void CycleAmmo(InputAction.CallbackContext context) //switches ammo
    {
        int prevIndex = currentAmmoIndex;
        currentAmmoIndex++;
        if (currentAmmoIndex >= mushroomAmmoTypes.Count)
        {
            currentAmmoIndex = 0;
        }
		if (mushroomAmmoTypes.Count <= 1)
		{
            //play unable to switch sound
            FMODUnity.RuntimeManager.PlayOneShot(unableChangeSound);

        }
        gunAnimator.SetInteger("AmmoIndex", currentAmmoIndex);
        gunAnimator.SetTrigger("Switch");
        wheel.transform.eulerAngles = new Vector3(wheel.transform.rotation.x, wheel.transform.rotation.y, 90 * currentAmmoIndex);
        UpdateSoundAdresses();
    }

    private void UpdateSoundAdresses()
    {
		if (mushroomAmmoTypes.Count <= 0)
		{
            ammoFireAudioAddress = defaultAmmoFireAudioAddress;
            return;
		}
        foreach (var item in audioPairs)
        {
            if (item.ammoTypeObject == mushroomAmmoTypes[currentAmmoIndex])
            {
                FMODUnity.RuntimeManager.PlayOneShot(item.ammoLoadingAudioAddress);
                ammoFireAudioAddress = item.ammoFiringAudioAddress;
                return;
            }
        }
        //play unable to switch sound;
        ammoFireAudioAddress = defaultAmmoFireAudioAddress;
        
    }

    [System.Serializable]
    public struct ammoAudioPair
    {
        public PlayerFunglebehaviour ammoTypeObject;
        public FMODUnity.EventReference ammoLoadingAudioAddress;
        public FMODUnity.EventReference ammoFiringAudioAddress;
    }

    public void AddAmmoType(PlayerFunglebehaviour ammoObject) //add a new ammo type
    {

        if (mushroomAmmoTypes.Contains(ammoObject))
        {
            return;
        }
        mushroomAmmoTypes.Add(ammoObject);
        UpdateAmmoVisuals();
        UpdateSoundAdresses();
        gunAnimator.SetTrigger("AmmoPickUp");
    }

    [ContextMenu("UpdateAmmoVisuals")]
    private void UpdateAmmoVisuals() //updated the visual on the gun by checking the ammo available against its slots and setting materials to match
    {
        if (mushroomAmmoTypes.Count <= 0)
        {
            return;
        }
        foreach (var slot in ammoSlotRenderers)
        {
            slot.gameObject.SetActive(false);
        }
        for (int i = 0; i < mushroomAmmoTypes.Count; i++)
        {
            ammoSlotRenderers[i].material = mushroomAmmoTypes[i].transform.GetComponentInChildren<MeshRenderer>().sharedMaterial;
            ammoSlotRenderers[i].gameObject.SetActive(true);
        }
    }
   
    private void Shoot(InputAction.CallbackContext context) //creates bullet and fires it
    {
        FMODUnity.RuntimeManager.PlayOneShot(ammoFireAudioAddress); //play fire sound or defaullt if unable to fire
        gunAnimator.SetTrigger("Fire");
        if (mushroomAmmoTypes.Count <= 0 && mushroomAmmoTypes.Count >= currentAmmoIndex)
        {
            return;
        }
        if (mushroomAmmoTypes[currentAmmoIndex] == null)
        {
            
            return; //no ammo loaded
        }
        BulletBehaviour tempbullet = Instantiate(bullet, firePoint.position, Quaternion.identity);
        if (Physics.Raycast(cameraTrans.position, cameraTrans.forward,out RaycastHit hit, maxGunLookAhead,mask)) //used to fire the bullet visually from the correct place
        {
            tempbullet.transform.LookAt(hit.point, transform.up);
        }
        else
        {
            tempbullet.transform.LookAt(cameraTrans.position + (cameraTrans.forward * maxGunLookAhead), transform.up);
        }
        var bulletRb = tempbullet.rigidbody;
        tempbullet.mushroomAmmoObject = mushroomAmmoTypes[currentAmmoIndex];
        tempbullet.launcher = this;
        bulletRb.GetComponentInChildren<Renderer>().material = mushroomAmmoTypes[currentAmmoIndex].GetComponentInChildren<Renderer>().sharedMaterial;
        bulletRb.AddForce(tempbullet.transform.forward * bulletFireForce, ForceMode.Impulse);
    }

    public void AddActiveBullet(GameObject bullet)
    {
        if (bulletCap != 0 && activeBullets.Count > bulletCap-1)
        {
            int amountLeft = activeBullets.Count - (bulletCap - 1);
            foreach (var item in activeBullets.GetRange(0, amountLeft))
            {
                var acidmushroomComp = item.GetComponent<AcidMushroom>();
                if (acidmushroomComp != null && acidmushroomComp.dissolving)
                    continue;
                else
                    Destroy(item);
            }
        }
        if (!activeBullets.Contains(bullet))
        {
            activeBullets.Add(bullet);
        }
    }
    public void RemoveActiveBullet(GameObject bullet)
    {
        if (activeBullets.Contains(bullet))
        {
            activeBullets.Remove(bullet);
        }
    }
}
