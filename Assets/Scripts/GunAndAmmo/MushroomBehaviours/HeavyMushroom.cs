using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class HeavyMushroom : PlayerFunglebehaviour
{
    Rigidbody parentRb;
    public float extraMass = 5;
    public float mushroomLifeTime = 5;
    FMOD.Studio.EventInstance HeavyActiveSound;
    public bool noTimeLimit = false;

    public override void Start()
    {
        //plays hit sound
        HeavyActiveSound = RuntimeManager.CreateInstance("event:/Sound Effects/Gun/HeavyActive");

        //if RB is hit then increase it's mass otherwise play miss sound
        if (transform.parent.TryGetComponent<Rigidbody>(out parentRb))
        {
            RuntimeManager.PlayOneShotAttached("event:/Sound Effects/Gun/Gun_HeavyImpact", gameObject);
            HeavyActiveSound.start();
            parentRb.mass += extraMass;
        }
        else
        {
            RuntimeManager.PlayOneShotAttached("event:/Sound Effects/Gun/Gun_HeavyMiss", gameObject);
        }
        if (!noTimeLimit)
        {
            //destroys after set time
            Destroy(gameObject, mushroomLifeTime);
        }
        base.Start();
    }

    public void Update()
    {
        RuntimeManager.AttachInstanceToGameObject(HeavyActiveSound, gameObject.transform);
    }

    public override void OnDestroy()
    {
        //remove extra mass and stop audio
        if (parentRb != null)
        {
            parentRb.mass -= extraMass;
        }
        HeavyActiveSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        HeavyActiveSound.release();
        base.OnDestroy();
    }
}
