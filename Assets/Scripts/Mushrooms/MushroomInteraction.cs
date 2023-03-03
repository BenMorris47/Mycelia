using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MushroomInteraction : ItemInteraction, IInteractable
{
    //This bool determines if the mushroom has been picked or not
    [SerializeField] bool isPicked;
    //uses events to call Grow() only when night hits for the first time
    private void OnEnable()
    {
        DayNightCycle.OnSunSet += () => Grow();
    }

    private void OnDisable()
    {
        DayNightCycle.OnSunSet -= () => Grow();
    }
    private void Start()
    {
        //cache mushroom components for later use
        itemMesh = GetComponent<MeshRenderer>();
        itemCollider = GetComponent<Collider>();
        itemMat = itemMesh.material;
        //childrenToDeactivate = GetComponentsInChildren<Transform>();
    }
    private void OnValidate()
    {
        //collect all children in the mushroom to disable
        for (int i = 0; i < transform.childCount; i++)
        {
            childrenToDeactivate.Add(transform.GetChild(i).gameObject);
        }
    }
    public new void OnEndHover()
    {
        //
        itemMat.SetFloat ("_Highlighted", 0);
    }

    public new void OnInteract()
    {
        if (!isPicked)
        {
            PickUp();
        }
    }

    public new void OnStartHover()
    {
        //
        itemMat.SetFloat ("_Highlighted", 1);
    }
    /// <summary>
    /// Adds the mushroom to the inventory of the player, disables picking, and deactivates its meshrenderer and collider
    /// </summary>
    protected override void PickUp()
    {
        if (pickUpAble)
        {
            isPicked = true;
            //Inventory.instance.AddItem(item.itemId, itemPickupAmount);
            itemCollider.enabled = false;
            itemMesh.enabled = false;
            //disable children ie spray effect
            foreach(GameObject childObject in childrenToDeactivate)
            {
                childObject.gameObject.SetActive(false);
            }
        }
    }
    /// <summary>
    /// Re-enables the meshrenderer and collider and enables picking again
    /// </summary>
    private void Grow() 
    {
        if (!isPicked)
            return;
        isPicked = false;
        itemCollider.enabled = true;
        itemMesh.enabled = true;
        //enable children ie spray effect
        foreach (GameObject childObject in childrenToDeactivate)
        {
            childObject.gameObject.SetActive(true);
        }
    }
}
