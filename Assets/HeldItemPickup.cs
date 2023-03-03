using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HeldItemPickup : MonoBehaviour,IInteractable
{
    public HeldItem heldItemController;
    public GameObject objectToAdd;
    public string InteractMessage => interactMessage;
    public string interactMessage = "pick up";
    public bool destroyOnInteract = false;
    public FMODUnity.EventReference PickupSound;
    public UnityEvent pickupEvents;


    public float MaxRange => 10;

    public void OnEndHover()
    {
        
    }

    public void OnInteract()
    {
        heldItemController?.AddItemToHeld(objectToAdd);
        FMODUnity.RuntimeManager.PlayOneShot(PickupSound);
        pickupEvents?.Invoke();
        if (destroyOnInteract)
        {
            Destroy(gameObject);
        }
    }

    public void OnStartHover()
    {
        
    }
}
