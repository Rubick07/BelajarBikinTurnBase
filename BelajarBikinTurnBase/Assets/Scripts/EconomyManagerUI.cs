using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EconomyManagerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyTextMeshPro;

    private void Start()
    {
        EconomyManager.instance.OnMoneyChanged += EconomyManager_OnMoneyChanged;
        
        UpdateVisual(EconomyManager.instance.GetMoney());
    }

    private void EconomyManager_OnMoneyChanged(object sender, int e)
    {
        UpdateVisual(e);
    }

    public void UpdateVisual(int e)
    {
        moneyTextMeshPro.text = "RP" + e.ToString("N0");
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

}
