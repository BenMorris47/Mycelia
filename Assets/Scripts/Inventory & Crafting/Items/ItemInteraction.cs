using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour, IInteractable
{
    //this is the material component of the item
    [Tooltip("Material of the gameObject")]
    public Material itemMat;

    //this is the meshrenderer component of the item
    [Tooltip("MeshRenderer of the gameObject")]
    public MeshRenderer itemMesh;

    //this is the collider component of the item
    [Tooltip("Collider of the gameObject")]
    public Collider itemCollider;

    //this bool determines if the item can be picked up or not
    [Tooltip("Is the item picked up?")]
    public bool pickUpAble;

    //this is the Item class assigned to the object to be picked up
    //public Item item;
    
    //this is the number of items being added
    [Tooltip("How many items are going to be added?")]
    public int itemPickupAmount = 1;
    //this is the range from which the item can be interacted with
    public float MaxRange => 10;
    //this is the message which will appear 
    public string InteractMessage => interactMessage;
    public string interactMessage = "pick up";
    public List<GameObject> childrenToDeactivate;

    //this is the id or name of the item
    public string itemName;
    private void Start()
    {
        //cache item components for later use
        itemMesh = GetComponent<MeshRenderer>();
        itemCollider = GetComponent<Collider>();
        itemMat = itemMesh.material;
    }
    private void OnValidate()
    {
        //collect all children in the mushroom to disable
        
        //commented out in case we have additional parts on the item we want to disable
        
        for (int i = 0; i < transform.childCount; i++)
        {
            if (!childrenToDeactivate.Contains(transform.GetChild(i).gameObject))
            {
                childrenToDeactivate.Add(transform.GetChild(i).gameObject);
            }  
        }
        
    }
    public void OnEndHover()
    {

    }

    public void OnInteract()
    {
        PickUp();
    }

    public void OnStartHover()
    {
        //
        itemMat.SetFloat("_Highlighted", 1);
    }
    /// <summary>
    /// Adds the item to the inventory of the player, disables picking, and deactivates its meshrenderer and collider
    /// </summary>
    protected virtual void PickUp()
    {
        if (pickUpAble)
        {
            //Inventory.instance.AddItem(item.itemId, itemPickupAmount);
            itemCollider.enabled = false;
            itemMesh.enabled = false;
            //disable children ie spray effect
            foreach (GameObject childObject in childrenToDeactivate)
            {
                childObject.gameObject.SetActive(false);
            }
            Inventory.instance.AddItem(itemName, itemPickupAmount);
        }
    }

    private void pickUpJournalEntry()
    {

    }

    private void interactKeyItem()
    {
        
    }
}
