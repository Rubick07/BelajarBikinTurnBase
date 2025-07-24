using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnSystemUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentUnitText;

    private void Start()
    {
        TurnSystem.Instance.OnUnitTurnChanged += TurnSystem_OnUnitTurnChanged;
    }

    private void TurnSystem_OnUnitTurnChanged(object sender, System.EventArgs e)
    {
        SetNameText();
    }

    private void SetNameText()
    {
        currentUnitText.text = TurnSystem.Instance.GetCurrentUnit().name;
    }

}
