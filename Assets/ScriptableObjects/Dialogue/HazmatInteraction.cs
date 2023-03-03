using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HazmatInteraction : MonoBehaviour, IInteractable
{
    public string InteractMessage => interactMessage;
    public string interactMessage = "poke body";
    public bool destroyOnInteract = false;
    public FMODUnity.EventReference InteractSound;

    public float MaxRange => 10;

    public void OnEndHover()
    {

    }

    public void OnInteract()
    {
		FMODUnity.RuntimeManager.PlayOneShot(InteractSound);
    }
    public void OnStartHover()
    {

    }
}

