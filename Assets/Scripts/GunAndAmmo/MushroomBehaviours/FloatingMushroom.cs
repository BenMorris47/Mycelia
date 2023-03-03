using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FloatingMushroom : PlayerFunglebehaviour
{
    Rigidbody parentRb;
    public float floatValue = 20;
    public float mushroomLifeTime = 5;
    FMOD.Studio.EventInstance FloatyActiveSound;
    public bool noTimeLimit = false;
    public override void Start()
    {
        //play sound for hit
        RuntimeManager.PlayOneShotAttached("event:/Sound Effects/Gun/Gun_FloatyImpact", gameObject);
        FloatyActiveSound = RuntimeManager.CreateInstance("event:/Sound Effects/Gun/FloatyActive");
        if (transform.parent.TryGetComponent<Rigidbody>(out parentRb))
        {
            FloatyActiveSound.start();
        }
        if (!noTimeLimit)
        {//destroy after set time
            Destroy(gameObject, mushroomLifeTime);
        }
        base.Start();
    }

    private void FixedUpdate()
    {
        //add upward force
        if (parentRb != null)
        {
            parentRb.AddForceAtPosition(Vector3.up * floatValue,transform.position, ForceMode.Force);
        }
    }

    private void Update()
    {
        RuntimeManager.AttachInstanceToGameObject(FloatyActiveSound, gameObject.transform);
    }

    public override void OnDestroy()
    {
        //stop sound when destorying
        FloatyActiveSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        FloatyActiveSound.release();
        base.OnDestroy();
    }
}
