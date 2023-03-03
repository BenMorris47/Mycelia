using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalInteraction : ItemInteraction, IInteractable
{
    public JournalEntry entryToPickUp;
    public void OnInteract()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Sound Effects/Player (Plyr)/Actions/Plyr_JournalPickup");
        PickUp();
    }

    protected virtual void PickUp()
    {
        if (pickUpAble)
        {
            JournalUIManager.instance.AppendEntry(entryToPickUp);
            itemCollider.enabled = false;
            itemMesh.enabled = false;
            //disable children ie spray effect
            foreach (GameObject childObject in childrenToDeactivate)
            {
                childObject.gameObject.SetActive(false);
            }
            Destroy(gameObject);
        }
    }
}
