using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : MonoBehaviour, IInteractable
{
    [SerializeField] private MarketItemSO marketItemSO;

    public void Interact()
    {
        MarketUI.instance.SetMarket(this);
    }

    public void BuyItem(ItemBase itemBase)
    {
        if (EconomyManager.instance.UseMoney(itemBase.GetItemPrice()))
        {
            InventoryManager.instance.AddItem(itemBase);
        }
        else
        {

        }
        
    }

    public void SellItem(ItemBase itemBase)
    {
        if(InventoryManager.instance.GetItemAmounts(itemBase) != 0)
        {
            InventoryManager.instance.RemoveItem(itemBase,1);
            EconomyManager.instance.AddMoney(itemBase.GetItemPrice()/2);
        }
        else
        {
            Debug.Log("ITEM TIDAK CUKUP UNTUK DIJUAL");
        }
    }

    public ItemBase[] GetItemToSellInMarket()
    {
        return marketItemSO.ItemToSellInMarket;
    }

}
