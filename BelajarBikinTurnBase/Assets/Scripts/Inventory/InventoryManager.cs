using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public event EventHandler OnInventoryChanged;

    private Dictionary<ItemBase, int> inventoryDictionary = new Dictionary<ItemBase, int>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    public void AddItem(ItemBase itemBase)
    {
        if (inventoryDictionary.ContainsKey(itemBase))
        {
            inventoryDictionary[itemBase]++;
            //Debug.Log(itemBase.name + " " +inventoryDictionary[itemBase]);
        }
        else
        {
            inventoryDictionary.Add(itemBase, 1);
        }

        OnInventoryChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool UseItem(ItemBase itemBase)
    {
        if (inventoryDictionary.ContainsKey(itemBase))
        {
            if(inventoryDictionary[itemBase] == 0)
            {
                Debug.Log(itemBase +" ITEM HABIS");
                return false;
            }

            itemBase.UseItem();
            RemoveItem(itemBase, 1);
            Debug.Log(itemBase.name + " " + inventoryDictionary[itemBase]);

            return true;
        }
        else
        {
            Debug.Log("ITEM NOT FOUND");
            return false;
        }
    }

    public void RemoveItem(ItemBase itemBase, int AmountToRemove)
    {
        inventoryDictionary[itemBase] -= AmountToRemove;

        OnInventoryChanged?.Invoke(this,EventArgs.Empty);
    }


    public int GetItemAmounts(ItemBase itemBase)
    {
        bool itemBaseFound = inventoryDictionary.ContainsKey(itemBase);
        if (itemBaseFound)
        {
            return inventoryDictionary[itemBase];
        }
        else
        {
            return 0;
        }
    }

    public Dictionary<ItemBase, int> GetInventoryDictionary()
    {
        return inventoryDictionary;
    }

}
