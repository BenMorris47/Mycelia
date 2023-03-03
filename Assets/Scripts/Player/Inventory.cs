using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //USED FOR OLD CONCEPT NO LONGER NEEDED
    public static Inventory instance = null;
    private Dictionary<string, int> inventoryDic = new Dictionary<string, int>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void AddItem(string item, int amount = 1)
    {
        if (inventoryDic.ContainsKey(item))
        {
            inventoryDic[item] += amount;
        }
        else
        {
            inventoryDic.Add(item, amount);
        }
    }
    public void RemoveItem(string item, int amount = 1)
    {
        if (inventoryDic.ContainsKey(item))
        {
            inventoryDic[item] -= amount;
            if (inventoryDic[item] < 0)
                inventoryDic.Remove(item);
        }
        else
        {
            Debug.LogError("Key doesn't exist");
        }
    }

    public bool IsItemInInventory(string item, int amount = 1)
    {
        if (inventoryDic.ContainsKey(item))
        {
            if (inventoryDic[item] >= amount)
                return true;
            else
                return false;
        }
        else
        {
            Debug.LogError("Key doesn't exist");
            return false;
        }
    }

}
