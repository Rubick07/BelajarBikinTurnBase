using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class HeroPartyManager : MonoBehaviour
{
    public static HeroPartyManager instance;

    [Header("PartSO Reference")]
    [SerializeField] private PlayerPartySO playerPartySO;

    private List<HeroDynamicData> heroDynamicDataList = new List<HeroDynamicData>();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        foreach(HeroDataSO heroDataSO in playerPartySO.GetHeroDataSOList())
        {
            HeroDynamicData heroDynamicData = new HeroDynamicData(heroDataSO);
            heroDynamicDataList.Add(heroDynamicData);
            Debug.Log("Add New Hero Data: "+ heroDataSO.name);
        }

    }

    public PlayerPartySO GetPlayerPartySO()
    {
        return playerPartySO;
    }

    public List<HeroDynamicData> GetHeroDynamicDataList()
    {
        return heroDynamicDataList;
    }
}
