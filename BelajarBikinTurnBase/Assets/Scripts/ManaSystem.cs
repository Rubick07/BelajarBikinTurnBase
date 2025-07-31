using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ManaSystem : MonoBehaviour
{
    public event EventHandler OnConsumeMana;

    [SerializeField] private int mana = 100;
    private int maxMana;

    private void Awake()
    {
        maxMana = mana;
    }

    public bool ConsumeMana(int manaAmount)
    {
        if(manaAmount <= mana)
        {
            mana -= manaAmount;
            OnConsumeMana?.Invoke(this, EventArgs.Empty);
            return true;
        }
        else
        {
            Debug.Log("NOT ENOUGHT MANA");
            return false;
        }

    }

    public void RestoreMana(int manaAmount)
    {
        mana += manaAmount;
    }

    public int GetMana()
    {
        return mana;
    }

    public float GetManaNormalized()
    {
        return (float)mana / maxMana;
    }
}
