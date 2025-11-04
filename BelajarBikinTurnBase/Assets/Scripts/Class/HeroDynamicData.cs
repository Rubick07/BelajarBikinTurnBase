using UnityEngine;
using System;
public class HeroDynamicData
{
    public string name;
    public int health;
    public int maxHealth;

    public int mana;
    public int maxMana;

    public static event EventHandler<int> OnAnyHealthChanged;
    public static event EventHandler<int> OnAnyManaChanged;

    private HeroDataSO heroDataSO;

    public HeroDynamicData(HeroDataSO heroDataSO)
    {
        name = heroDataSO.name;

        health = heroDataSO.GetMaxHealth();
        maxHealth = heroDataSO.GetMaxHealth();

        mana = heroDataSO.GetMaxMana();
        maxMana = heroDataSO.GetMaxMana();

        this.heroDataSO = heroDataSO;
    }

    public void ModifyHealth(int mod)
    {
        health += mod;

        health = Mathf.Clamp(health, 0, maxHealth);

        OnAnyHealthChanged?.Invoke(this, health);
    }

    public float GetHealthNormalized()
    {
        return (float)health / maxHealth;
    }

    public void ModifyMana(int mod)
    {
        mana += mod;

        mana = Mathf.Clamp(mana, 0, maxMana);

        OnAnyManaChanged?.Invoke(this, mana);
    }


    public float GetManaNormalized()
    {
        return (float)mana / maxMana;
    }

    public HeroDataSO GetHeroDataSO()
    {
        return heroDataSO;
    }

    public void InfoLog()
    {

    }


}
