using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : ScriptableObject
{
    public enum ItemType
    {
        Consumable,
        Equipment
    }

    [SerializeField] protected int itemPrice;
    [SerializeField] protected ItemType itemType;
    [TextArea(5, 10)]
    [SerializeField] protected string itemDescription;
    [SerializeField] protected Sprite itemSprite;

    public virtual void UseItem()
    {
        Debug.Log("Test");
    }

    public int GetItemPrice()
    {
        return itemPrice;
    }

    public ItemType GetItemType()
    {
        return itemType;
    }

    public Sprite GetItemSprite()
    {
        return itemSprite;
    }


}
