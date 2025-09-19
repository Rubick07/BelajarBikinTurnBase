using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{

    public event EventHandler OnDead;
    public event EventHandler OnDamaged;
    public event EventHandler OnRestoreHealth;

    [SerializeField] private int health = 100;
    private int maxHealth;

    private int lastDamageValue;
    private void Awake()
    {
        maxHealth = health;
    }

    public void RestoreHealth(int restoreAmount)
    {
        health += restoreAmount;

        OnRestoreHealth?.Invoke(this, EventArgs.Empty);

    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;
        lastDamageValue = damageAmount;
        if (health < 0)
        {
            health = 0;
        }

        OnDamaged?.Invoke(this, EventArgs.Empty);

        if (health == 0)
        {
            Die();
        }

    }

    private void Die()
    {
        OnDead?.Invoke(this, EventArgs.Empty);
    }

    public int GetLastDamageValue()
    {
        return lastDamageValue;
    }

    public int GetHealth()
    {
        return health;
    }

    public float GetHealthNormalized()
    {
        return (float)health / maxHealth;
    }
}
