using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Items/HealingItemSO")]
public class HealingItem : ItemBase
{
    public int healthAmount;

    public override void UseItem(HeroDataSO heroDataSO)
    {
        heroDataSO.ModifyHealth(healthAmount);
        Debug.Log(heroDataSO.name + "Healed: " + healthAmount);
    }

}
