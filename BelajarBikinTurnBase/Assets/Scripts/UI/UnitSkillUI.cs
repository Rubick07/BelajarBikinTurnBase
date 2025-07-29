using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class UnitSkillUI : MonoBehaviour
{
    [SerializeField] private Transform skillButtonPrefab;
    [SerializeField] private Transform skillButtonContainerTransform;

    private List<UnitSkillButtonUI> skillButtonList;


    private void Awake()
    {
        skillButtonList = new List<UnitSkillButtonUI>();
    }

    private void Start()
    {
        UnitActionSystem.Instance.OnStateChanged += UnitActionSystem_OnStateChanged;
        UnitActionSystem.Instance.OnSelectedSkillActionChanged += UnitActionSystem_OnSelectedSkillActionChanged;
        TurnSystem.Instance.OnUnitTurnChanged += TurnSystem_OnUnitTurnChanged;

        Hide();
    }

    private void UnitActionSystem_OnSelectedSkillActionChanged(object sender, System.EventArgs e)
    {
        UpdateSelectedVisual();
    }

    private void TurnSystem_OnUnitTurnChanged(object sender, System.EventArgs e)
    {
        if (TurnSystem.Instance.IsCurrentPlayerTurn())
        {
            CreateUnitSkillButton();
        }
        Hide();
    }

    private void UnitActionSystem_OnStateChanged(object sender, System.EventArgs e)
    {
        if (UnitActionSystem.Instance.IsSelectMagic())
        {
            Show();
        }
        else
        {
            Hide();
        }
        UpdateSelectedVisual();
    }

    private void CreateUnitSkillButton()
    {
        foreach(Transform buttonTransform in skillButtonContainerTransform)
        {
            Destroy(buttonTransform.gameObject);
        }

        skillButtonList.Clear();

        Unit currentUnitTurn = TurnSystem.Instance.GetCurrentUnit();

        foreach(SkillAction skillAction in currentUnitTurn.GetSkillActionList())
        {
            Transform skillButtonTransform = Instantiate(skillButtonPrefab, skillButtonContainerTransform);
            UnitSkillButtonUI skillButtonUI = skillButtonTransform.GetComponent<UnitSkillButtonUI>();
            skillButtonUI.SetSkillAction(skillAction);

            skillButtonList.Add(skillButtonUI);

        }

        if(skillButtonList.Count != 0)
            EventSystem.current.SetSelectedGameObject(skillButtonList[0].gameObject);
    }

    private void UpdateSelectedVisual()
    {
        foreach (UnitSkillButtonUI unitSkillButtonUI in skillButtonList)
        {
            unitSkillButtonUI.UpdateSelectedVisual();
        }

    }


    public void Show()
    {
        EventSystem.current.SetSelectedGameObject(skillButtonList[0].gameObject);
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
