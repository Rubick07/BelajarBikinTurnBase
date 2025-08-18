using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UnitSkillButtonUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private TextMeshProUGUI costtextMeshPro;
    [SerializeField] private Image image;
    [SerializeField] private Button button;
    [SerializeField] private GameObject selectedVisual;

    private SkillAction baseAction;

    public void SetSkillAction(SkillAction skillAction)
    {
        this.baseAction = skillAction;
        image.sprite = skillAction.GetSkillImage();
        textMeshPro.text = skillAction.GetActionName().ToUpper();
        costtextMeshPro.text = skillAction.GetSkillCost().ToString() + " SP";

        button.onClick.AddListener(() =>
        {
            //skillAction.GetUnit().GetManaSystem().ConsumeMana(skillAction.GetSkillCost());
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
