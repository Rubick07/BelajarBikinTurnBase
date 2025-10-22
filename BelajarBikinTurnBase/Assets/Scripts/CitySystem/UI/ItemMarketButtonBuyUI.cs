using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemMarketButtonBuyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemNameTextMeshPro;
    [SerializeField] private TextMeshProUGUI itemAmountsTextMeshPro;
    [SerializeField] private TextMeshProUGUI itemCostTextMeshPro;
    [SerializeField] private Image itemImage;
    [SerializeField] private Button button;

    private ItemBase itemBase;

    private void Start()
    {
        InventoryManager.instance.OnInventoryChanged += InventoryManager_OnInventoryChanged;
    }

    private void InventoryManager_OnInventoryChanged(object sender, System.EventArgs e)
    {
        Debug.Log("Test");
        Debug.Log(itemBase);
        itemAmountsTextMeshPro.text = InventoryManager.instance.GetItemAmounts(itemBase).ToString();
    }

    public void SetItemBaseButton(ItemBase itembase)
    {
        this.itemBase = itembase;
        itemImage.sprite = itemBase.GetItemSprite();
        itemNameTextMeshPro.text = itembase.name.ToUpper();
        itemAmountsTextMeshPro.text = InventoryManager.instance.GetItemAmounts(itembase).ToString();
        itemCostTextMeshPro.text = "RP"+itemBase.GetItemPrice().ToString("N0");

        button.onClick.AddListener(() =>
        {
            MarketUI.instance.GetMarket().BuyItem(itembase);
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
