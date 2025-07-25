using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEnemyUI : MonoBehaviour
{
    private void Start()
    {
        TurnSystem.Instance.OnUnitTurnChanged += TurnSystem_OnUnitTurnChanged;
        UnitActionSystem.Instance.OnSelectedEnemyUnitChanged += UnitActionSystem_OnSelectedEnemyUnitChanged;
    }

    private void TurnSystem_OnUnitTurnChanged(object sender, System.EventArgs e)
    {
        if (TurnSystem.Instance.IsCurrentPlayerTurn())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void UnitActionSystem_OnSelectedEnemyUnitChanged(object sender, System.EventArgs e)
    {
        transform.position = UnitActionSystem.Instance.GetSelectedEnemyUnit().transform.position;
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

}
