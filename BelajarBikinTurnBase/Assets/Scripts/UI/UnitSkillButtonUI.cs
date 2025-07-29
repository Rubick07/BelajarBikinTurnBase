using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UnitSkillButtonUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private Button button;
    [SerializeField] private GameObject selectedVisual;

    private SkillAction baseAction;

    public void SetSkillAction(SkillAction skillAction)
    {
        this.baseAction = skillAction;
        textMeshPro.text = skillAction.GetActionName().ToUpper();
        button.onClick.AddListener(() =>
        {
            Debug.Log(skillAction.GetActionName().ToUpper());
        });
    }

    public void UpdateSelectedVisual()
    {
        SkillAction selectedSkillAction = UnitActionSystem.Instance.GetSkillAction();
        selectedVisual.SetActive(baseAction == selectedSkillAction);
    }


    public SkillAction GetThisBaseSkillButton()
    {
        return baseAction;
    }
}
