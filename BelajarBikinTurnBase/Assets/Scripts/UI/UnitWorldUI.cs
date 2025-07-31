using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitWorldUI : MonoBehaviour
{

    private void Start()
    {
        UnitActionSystem.Instance.OnActionStarted += UnitActionSystem_OnActionStarted;
        TurnSystem.Instance.OnUnitTurnChanged += TurnSystem_OnUnitTurnChanged;

        BaseAction.OnAnyActionStart += BaseAction_OnAnyActionStart;

        Hide();
    }

    private void BaseAction_OnAnyActionStart(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void TurnSystem_OnUnitTurnChanged(object sender, System.EventArgs e)
    {
        if (!TurnSystem.Instance.GetCurrentUnit().IsEnemy())
        {
            if(TurnSystem.Instance.GetCurrentUnit().gameObject == transform.parent.gameObject)
            {
                Show();
            }
        }
        else
        {
            Hide();
        }
    }

    private void UnitActionSystem_OnActionStarted(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        UnitActionSystem.Instance.OnActionStarted -= UnitActionSystem_OnActionStarted;
        TurnSystem.Instance.OnUnitTurnChanged -= TurnSystem_OnUnitTurnChanged;

        BaseAction.OnAnyActionStart -= BaseAction_OnAnyActionStart;
    }

}
