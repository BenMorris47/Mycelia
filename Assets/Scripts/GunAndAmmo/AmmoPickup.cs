using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public PlayerFunglebehaviour ammoType;
    public void PickUp()
    {
        //Add the new ammo type to the launcher
        MushroomLauncher.instance.AddAmmoType(ammoType);
        Destroy(gameObject);
    }
}
