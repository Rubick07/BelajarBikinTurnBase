using System.Collections.Generic;
using UnityEngine;

public class PlayerPartyUICity : MonoBehaviour
{
    [SerializeField] private Transform playerPartyUIContainerTransform;
    [SerializeField] private Transform unitPartyUIPrefab;

    private List<HeroPartyUI> heroPartyUIList = new List<HeroPartyUI>();

    private void Start()
    {
        CreateHeroUI();
    }

    private void CreateHeroUI()
    {
        RemoveButtonList();

        foreach (HeroDataSO herodata in HeroPartyManager.instance.GetPlayerPartySO().GetHeroDataSOList())
        {
            Transform heroPartyUITransform = Instantiate(unitPartyUIPrefab, playerPartyUIContainerTransform);
            HeroPartyUI heroPartyUI =
                heroPartyUITransform.GetComponent<HeroPartyUI>();

            heroPartyUI.SetUp(herodata);

            heroPartyUIList.Add(heroPartyUI);

        }
    }

    private void RemoveButtonList()
    {
        foreach (Transform buttonTransform in playerPartyUIContainerTransform)
        {
            Destroy(buttonTransform.gameObject);
        }

        heroPartyUIList.Clear();
    }

}
