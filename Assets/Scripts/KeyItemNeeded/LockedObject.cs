using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LockedObject : MonoBehaviour, IInteractable
{
    bool hasBeenTouchedBefore = false;
    bool unlocked = false;
    [Tooltip("This is the string for when the object is locked")]
    public string lockedString = "Open Object";
    [Tooltip("This is the string for when 'unlocking' the object")]
    public string unlockingString = "Unlock Object";
    [Tooltip("This is the string for when the object is unlocked")]
    public string unlockedString = "Open Object";

    public UnityEvent unlockEvents;


    [Header("IInteractable Things")]
    public float maxRange = 10;

    public string InteractMessage => interactMessage;
    string interactMessage = "";

    public float MaxRange => maxRange;

    public void Open()
    {
        unlocked = true;
    }

    public void Interact()
    {
        
    }

    public void OnStartHover()
    {
        if (!unlocked)
        {
            interactMessage = lockedString;
            //Change text to show "This {object} is locked";
        }
        if (unlocked && !hasBeenTouchedBefore)
        {
            interactMessage = unlockingString;
            //Change text to show "Press {interactButton} to unlock {object}";
            hasBeenTouchedBefore = true;


            //Animation here??
        }
        else if (unlocked && hasBeenTouchedBefore)
        {
            interactMessage = unlockedString;
            //Change text to show "Press {interactButton} to open {object}";

            //Open {object} function here
        }
    }

    public void OnInteract()
    {
        if (!unlocked)
        {
            interactMessage = "Door Is Locked";
            return;
        }
        else
        {
            unlockEvents?.Invoke();
            Destroy(gameObject); //Temporarily destroy the GameObject
        }
    }

    public void OnEndHover()
    {
        interactMessage = "";
    }
}
