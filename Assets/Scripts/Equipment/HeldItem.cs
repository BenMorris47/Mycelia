using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeldItem : MonoBehaviour
{
    public GameObject currentHeldItem;

    public List<GameObject> objectsWhichCanBeHeld;
    int currentHeldItemIndex = 0;

    private void OnEnable()
    {
        ControlsManager.instance.controls.PlayerMovement.ChangeHeldItem.performed += context => ChangeItem(context);

        currentHeldItem = objectsWhichCanBeHeld[currentHeldItemIndex];
        currentHeldItem.SetActive(true);
    }

    private void ChangeItem(InputAction.CallbackContext context)
    {
        if (objectsWhichCanBeHeld.Count <= 1)
            return;

        Debug.Log($"Scroll Wheel is {context.ReadValue<Vector2>().y}");
        //currentHeldItemIndex += (int)context.ReadValue<Vector2>().y;

        //Cycles though the inventory indices.... should've just used % 
        if (currentHeldItemIndex > objectsWhichCanBeHeld.Count - 1)
        {
            currentHeldItemIndex = 0;
        }
        else if (currentHeldItemIndex <= 0)
        {
            currentHeldItemIndex = objectsWhichCanBeHeld.Count - 1;
        }
        EquipAtIndex(currentHeldItemIndex);
        //Call animation things here???? (there is no animation)

        //Change Control Functions for the itemHitHere, give or take anyways. Could have them be in OnEnable and OnDisable for the stuff
    }

    /// <summary>
    /// Equips an item at a given index
    /// </summary>
    /// <param name="index"></param>
    private void EquipAtIndex(int index)
    {
        currentHeldItemIndex = index;
        if (currentHeldItem != null)
            currentHeldItem.SetActive(false);
        currentHeldItem = objectsWhichCanBeHeld[index];
        currentHeldItem.SetActive(true);
    }

    /// <summary>
    /// Adds an item to the list of held items then equips it
    /// </summary>
    /// <param name="heldObject"></param>
    public void AddItemToHeld(GameObject heldObject)
    {
        objectsWhichCanBeHeld.Add(heldObject);
        EquipAtIndex(objectsWhichCanBeHeld.IndexOf(heldObject));
        RemoveNullHeldItem();
    }

    private void RemoveNullHeldItem()
    {
        //Loop through and remove any null entries
        foreach (var item in objectsWhichCanBeHeld)
        {
            if (item == null)
            {
                objectsWhichCanBeHeld.Remove(item);
                RemoveNullHeldItem();
                break;
            }
        }
    }
}
