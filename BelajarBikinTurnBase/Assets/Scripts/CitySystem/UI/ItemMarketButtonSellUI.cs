using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemMarketButtonSellUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemNameTextMeshPro;
    [SerializeField] private TextMeshProUGUI itemAmountsTextMeshPro;
    [SerializeField] private TextMeshProUGUI itemSellCostTextMeshPro;
    [SerializeField] private Image itemImage;
    [SerializeField] private Button button;

    private ItemBase itemBase;

    private void Start()
    {
        InventoryManager.instance.OnInventoryChanged += InventoryManager_OnInventoryChanged;
    }

    private void InventoryManager_OnInventoryChanged(object sender, System.EventArgs e)
    {
        itemAmountsTextMeshPro.text = InventoryManager.instance.GetItemAmounts(itemBase).ToString();
    }

    public void SetItemBaseButton(ItemBase itembase)
    {
        this.itemBase = itembase;
        itemImage.sprite = itemBase.GetItemSprite();
        itemNameTextMeshPro.text = itembase.name.ToUpper();
        itemAmountsTextMeshPro.text = InventoryManager.instance.GetItemAmounts(itembase).ToString();

        int ItemSellCost = itembase.GetItemPrice() / 2;
        itemSellCostTextMeshPro.text = "RP" + ItemSellCost.ToString("N0");

        button.onClick.AddListener(() =>
        {
            MarketUI.instance.GetMarket().SellItem(itembase);
        });
    }

    public Button GetButton()
    {
        return button;
    }

    private void OnDestroy()
    {
        InventoryManager.instance.OnInventoryChanged -= InventoryManager_OnInventoryChanged;
    }

}
