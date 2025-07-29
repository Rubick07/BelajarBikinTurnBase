using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEnemyUI : MonoBehaviour
{
    private bool isActive;
    private Vector3 targetPosition;

    private void Start()
    {
        TurnSystem.Instance.OnUnitTurnChanged += TurnSystem_OnUnitTurnChanged;
        UnitActionSystem.Instance.OnSelectedEnemyUnitChanged += UnitActionSystem_OnSelectedEnemyUnitChanged;
        UnitActionSystem.Instance.OnStateChanged += UnitActionSystem_OnStateChanged;
    }

    private void Update()
    {
        if (!isActive)
            return;

        Vector3 moveDirection = (targetPosition - transform.position).normalized;

        float moveSpeed = 8f;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        float stoppingDistance = .1f;
        if (Vector3.Distance(transform.position, targetPosition) < stoppingDistance)
        {
            isActive = false;
        }

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

    private void UnitActionSystem_OnStateChanged(object sender, System.EventArgs e)
    {
        if (UnitActionSystem.Instance.IsSelectAction() || UnitActionSystem.Instance.IsSelectEnemy())
        {
            Show();
        }
        else if (UnitActionSystem.Instance.IsSelectMagic())
        {
            Hide();
        }
        
    }


    private void UnitActionSystem_OnSelectedEnemyUnitChanged(object sender, System.EventArgs e)
    {
        isActive = true;
        targetPosition = UnitActionSystem.Instance.GetSelectedEnemyUnit().transform.position;
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
