using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerPartyUICity : MonoBehaviour
{
    [SerializeField] private Transform playerPartyUIContainerTransform;
    [SerializeField] private Transform unitPartyUIPrefab;

    private List<HeroPartyUI> heroPartyUIList = new List<HeroPartyUI>();

    private void Start()
    {
        CreateHeroUI();

        PauseUI.instance.OnStateChanged += PauseUI_OnStateChanged;
    }

    private void PauseUI_OnStateChanged(object sender, PauseUI.State e)
    {
        if(e == PauseUI.State.Selecthero)
        {
            EventSystem.current.SetSelectedGameObject(heroPartyUIList[0].GetButton().gameObject);
        }
    }

    private void CreateHeroUI()
    {
        RemoveButtonList();

        foreach (HeroDynamicData herodata in HeroPartyManager.instance.GetHeroDynamicDataList())
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

    private void OnDestroy()
    {
        PauseUI.instance.OnStateChanged -= PauseUI_OnStateChanged;
    }
}
