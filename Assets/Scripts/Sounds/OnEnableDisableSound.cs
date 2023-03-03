using FMODUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableDisableSound : MonoBehaviour
{
    public EventReference onEnableStringSound;
    public EventReference onDisableStringSound;

    private void OnEnable()
    {
        PlaySound(onEnableStringSound);
    }
    private void OnDisable()
    {
        PlaySound(onDisableStringSound);
    }

    private void PlaySound(EventReference playString)
    {
        if (!playString.IsNull)
        {
            RuntimeManager.PlayOneShot(playString);
        }
    }
}
