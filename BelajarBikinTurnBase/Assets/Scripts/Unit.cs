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
    private BaseAction[] baseActionArray;
    private HealthSystem healthSystem;
    private void Awake()
    {
        baseActionArray = GetComponents<BaseAction>();
        healthSystem = GetComponent<HealthSystem>();
    }

    private void Start()
    {
        healthSystem.OnDead += HealthSystem_OnDead;
        OnAnyUnitSpawned?.Invoke(this, EventArgs.Empty);
    }

    private void HealthSystem_OnDead(object sender, EventArgs e)
    {
        UnitActionSystem.Instance.SetTargetEnemy(0);

        Destroy(gameObject);
        
        OnAnyUnitDead?.Invoke(this, EventArgs.Empty);
    }

    public bool IsEnemy()
    {
        return isEnemy;
    }

    public int GetSpeed()
    {
        return speed;
    }

    public T GetAction<T>() where T : BaseAction
    {
        foreach (BaseAction baseAction in baseActionArray)
        {
            if (baseAction is T)
            {
                return (T)baseAction;
            }
        }
        return null;
    }

    public HealthSystem GetHealthSystem()
    {
        return healthSystem;
    }

}
