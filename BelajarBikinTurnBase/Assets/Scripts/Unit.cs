using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Unit : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private bool isEnemy;

    public static event EventHandler OnAnyUnitSpawned;
    public static event EventHandler OnAnyUnitDead;

    private void Start()
    {
        Debug.Log("Test");
        OnAnyUnitSpawned?.Invoke(this, EventArgs.Empty);
    }

    public bool IsEnemy()
    {
        return isEnemy;
    }

    public int GetSpeed()
    {
        return speed;
    }

}
