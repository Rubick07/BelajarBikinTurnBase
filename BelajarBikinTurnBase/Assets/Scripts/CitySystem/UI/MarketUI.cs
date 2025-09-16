using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using TMPro;

public class MarketUI : MonoBehaviour
{
    public enum State
    {
        MainMenu,
        BuyMenu,
        SellMenu,
        EquipmentMenu,

    }

    public event EventHandler OnShopUIOpen;
    public event EventHandler OnShopUIClose;
    public event EventHandler<State> OnStateChanged;
    public static MarketUI instance;

    [SerializeField] private State state;
    [Header("SHOP TEXT REFERENCE")]
    [SerializeField] private TextMeshProUGUI shopNameTextMeshPro;
    [SerializeField] private TextMeshProUGUI moneyTextMeshPro;
    [Header("SHOP BUTTON REFERENCE")]
    [SerializeField] private Button buyButton;
    [SerializeField] private Button sellButton;
    [SerializeField] private Button exitButton;

    [Header("Market Item REFERENCE")]
    [SerializeField] private Transform itemButtonBuyPrefab;
    [SerializeField] private Transform itemButtonSellPrefab;
    [SerializeField] private Transform itemButtonContainerTransform;

    private List<ItemMarketButtonBuyUI> itemButtonBuyList = new List<ItemMarketButtonBuyUI>();
    private List<ItemMarketButtonSellUI> itemButtonSellList = new List<ItemMarketButtonSellUI>();

    private Market currentMarket;

    private void Awake()
    {
        instance = this;

        buyButton.onClick.AddListener(CreateItemButtonBuy);
        sellButton.onClick.AddListener(CreateItemButtonSell);
        exitButton.onClick.AddListener(() => Hide());
    }

    private void Start()
    {
        EconomyManager.instance.OnMoneyChanged += EconomyManager_OnMoneyChanged;
        UpdateVisualMoneyText(EconomyManager.instance.GetMoney());
        RemoveButtonList();
        Hide();

    }

    private void EconomyManager_OnMoneyChanged(object sender, int e)
    {
        UpdateVisualMoneyText(e);
    }

    public void UpdateVisualMoneyText(int e)
    {
        moneyTextMeshPro.text = "RP" + e.ToString("N0");
    }

    private void CreateItemButtonBuy()
    {
        RemoveButtonList();

        foreach (ItemBase itembase in currentMarket.GetItemToSellInMarket())
        {
            Transform itemMarketButtonTransform = Instantiate(itemButtonBuyPrefab, itemButtonContainerTransform);
            ItemMarketButtonBuyUI itemMarketButtonUI =
                itemMarketButtonTransform.GetComponent<ItemMarketButtonBuyUI>();

            itemMarketButtonUI.SetItemBaseButton(itembase);

            itemButtonBuyList.Add(itemMarketButtonUI);

        }

        if (itemButtonBuyList.Count != 0)
        {
            EventSystem.current.SetSelectedGameObject(itemButtonBuyList[0].GetButton().gameObject);
        }

        SetMarketUIState(State.BuyMenu);
    }

    private void CreateItemButtonSell()
    {
        RemoveButtonList();

        foreach (ItemBase itembase in InventoryManager.instance.GetInventoryDictionary().Keys)
        {
            Transform itemMarketButtonTransform = Instantiate(itemButtonSellPrefab, itemButtonContainerTransform);
            ItemMarketButtonSellUI itemMarketButtonUI =
                itemMarketButtonTransform.GetComponent<ItemMarketButtonSellUI>();

            itemMarketButtonUI.SetItemBaseButton(itembase);

            itemButtonSellList.Add(itemMarketButtonUI);

        }

        if (itemButtonBuyList.Count != 0)
        {
            EventSystem.current.SetSelectedGameObject(itemButtonBuyList[0].GetButton().gameObject);
        }

        SetMarketUIState(State.SellMenu);
    }

    private void RemoveButtonList()
    {
        foreach (Transform buttonTransform in itemButtonContainerTransform)
        {
            Destroy(buttonTransform.gameObject);
        }

        itemButtonBuyList.Clear();
        itemButtonSellList.Clear();
    }

    public void SetMarketUIState(State state)
    {
        this.state = state;
        OnStateChanged?.Invoke(this, state);
    }

    public void Show()
    {
        EventSystem.current.SetSelectedGameObject(buyButton.gameObject);
        gameObject.SetActive(true);

        OnShopUIOpen?.Invoke(this, EventArgs.Empty);
    }

    public void Hide()
    {
        OnShopUIClose?.Invoke(this, EventArgs.Empty);
        gameObject.SetActive(false);
    }

    public void SetMarket(Market market)
    {
        currentMarket = market;
        RemoveButtonList();
        Show();
    }

    public Market GetMarket()
    {
        return currentMarket;
    }
}
