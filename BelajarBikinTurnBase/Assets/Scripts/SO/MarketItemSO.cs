using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Market")]
public class MarketItemSO : ScriptableObject
{
    [Tooltip("Item yang bakal dijual di market")]
    public ItemBase[] ItemToSellInMarket;
}
