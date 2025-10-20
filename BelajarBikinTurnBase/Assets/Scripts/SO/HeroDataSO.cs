using UnityEngine;
using System;

[CreateAssetMenu(fileName = "HeroData", menuName = "Scriptable Objects/HeroData")]
public class HeroDataSO : ScriptableObject
{
    [Header("REFERENCE")]
    [SerializeField] private Sprite heroSprite;
    [SerializeField] private string heroName;
    [Header("HERO STATS")]
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private int mana;
    [SerializeField] private int maxMana;

    [SerializeField] private GameObject heroPrefab;

    public EventHandler<int> OnHealthChanged;
    public EventHandler<int> OnManaChanged;


    public void ModifyHealth(int mod)
    {
        health += mod;

        OnHealthChanged?.Invoke(this, health);
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public float GetHealthNormalized()
    {
        return (float)health / maxHealth;
    }

    public void ModifyMana(int mod)
    {
        mana += mod;

        OnManaChanged?.Invoke(this, mana);
    }

    public int GetMana()
    {
        return mana;
    }

    public int GetMaxMana()
    {
        return maxMana;
    }

    public float GetManaNormalized()
    {
        return (float)mana / maxMana;
    }

    public Sprite GetHeroSprite()
    {
        return heroSprite;
    }

}
