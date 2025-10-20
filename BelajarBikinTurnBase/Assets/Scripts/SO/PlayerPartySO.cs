using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PlayerParty", menuName = "Scriptable Objects/PlayerParty")]
public class PlayerPartySO : ScriptableObject
{
    public List<HeroDataSO> heroPartyDataList;

    public List<HeroDataSO> GetHeroDataSOList()
    {
        return heroPartyDataList;
    }

}
