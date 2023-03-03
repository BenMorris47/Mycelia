using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyItem : MonoBehaviour, IInteractable
{
    public LockedObject itemToOpen;
    public UnityEvent pickedUpEvent;

    public string InteractMessage => interactMessage;
    public string interactMessage = "";
    public FMODUnity.EventReference PickupSound;

    public float MaxRange => 10;

    public void Interact()
    {
        itemToOpen.Open(); //Calling the open function so the {object} that is needed to be opened can be
        //Place this item in inv??
        pickedUpEvent?.Invoke();
        gameObject.SetActive(false);
    }

    public void OnEndHover()
    {
        interactMessage = "";
    }

    public void OnInteract()
    {
        Interact();
        FMODUnity.RuntimeManager.PlayOneShot(PickupSound);
    }

    public void OnStartHover()
    {
        interactMessage = "Pick Up";
    }
}