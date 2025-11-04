using UnityEngine;
using System;

[CreateAssetMenu(fileName = "HeroData", menuName = "Scriptable Objects/HeroData")]
public class HeroDataSO : ScriptableObject
{
    [Header("REFERENCE")]
    [SerializeField] private Sprite heroSprite;
    [SerializeField] private string heroName;
    [Header("HERO STATS")]
    [SerializeField] private int maxHealth;
    [SerializeField] private int maxMana;

    [SerializeField] private GameObject heroPrefab;
    public int GetMaxHealth()
    {
        return maxHealth;
    }


    public int GetMaxMana()
    {
        return maxMana;
    }

    public Sprite GetHeroSprite()
    {
        return heroSprite;
    }

}
