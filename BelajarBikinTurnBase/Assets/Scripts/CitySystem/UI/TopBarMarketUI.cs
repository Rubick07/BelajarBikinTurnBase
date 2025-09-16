using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopBarMarketUI : MonoBehaviour
{
    [SerializeField] private GameObject buyBarGameobject;
    [SerializeField] private GameObject sellBarGameobject;

    private void Start()
    {
        MarketUI.instance.OnStateChanged += MarketUI_OnStateChanged;
        UpdateTopBarUI(MarketUI.State.MainMenu);
    }

    private void MarketUI_OnStateChanged(object sender, MarketUI.State e)
    {
        UpdateTopBarUI(e);
    }

    private void UpdateTopBarUI(MarketUI.State e)
    {
        if (MarketUI.State.BuyMenu == e)
        {
            buyBarGameobject.SetActive(true);
            sellBarGameobject.SetActive(false);
        }
        else if (MarketUI.State.SellMenu == e)
        {
            sellBarGameobject.SetActive(true);
            buyBarGameobject.SetActive(false);
        }
        else
        {
            sellBarGameobject.SetActive(false);
            buyBarGameobject.SetActive(false);
        }
    }
}
