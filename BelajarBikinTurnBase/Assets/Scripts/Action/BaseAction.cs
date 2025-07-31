using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class BaseAction : MonoBehaviour
{
    public static event EventHandler OnAnyActionStart;
    public static event EventHandler OnAnyActionComplete;

    protected int skillCost;
    protected Unit unit;
    protected bool isActive;

    protected Action onActionComplete;

    private void Awake()
    {
        unit = GetComponent<Unit>();
    }

    public abstract string GetActionName();

    public abstract void TakeAction(Action onActionComplete);

    protected void ActionStart(Action onActionComplete)
    {
        isActive = true;
        this.onActionComplete = onActionComplete;

        OnAnyActionStart?.Invoke(this, EventArgs.Empty);
    }

    protected void ActionComplete()
    {
        isActive = false;
        onActionComplete();

        OnAnyActionComplete?.Invoke(this, EventArgs.Empty);
    }
    public Unit GetUnit()
    {
        return unit;
    }

    public int GetSkillCost()
    {
        return skillCost;
    }

    public EnemyAIAction GetBestEnemyAIAction()
    {
        List<EnemyAIAction> enemyAIActionList = new List<EnemyAIAction>();

        enemyAIActionList.Sort((EnemyAIAction a, EnemyAIAction b) => b.actionValue - a.actionValue);
        if (enemyAIActionList.Count > 0)
        {
            return enemyAIActionList[0];
        }
        else
        {
            //gk bisa ngapa ngapain
            return null;
        }

    }


    public abstract EnemyAIAction GetEnemyAIAction();



}
