using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EconomyManager : MonoBehaviour
{
    public static EconomyManager instance;

    public EventHandler<int> OnMoneyChanged;
    
    [SerializeField] private int money;
    
    
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

    public void AddMoney(int money)
    {
        this.money += money;
        OnMoneyChanged?.Invoke(this, this.money);
    }

    public bool UseMoney(int money)
    {
        if(money > this.money)
        {
            Debug.Log("DUIT TIDAK CUKUP");
            return false;
        }
        this.money -= money;
        OnMoneyChanged?.Invoke(this, this.money);
        return true;
    }

    public int GetMoney()
    {
        return money;
    }



}
