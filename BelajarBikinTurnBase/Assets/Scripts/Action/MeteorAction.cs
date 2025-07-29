using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorAction : SkillAction
{
    public event EventHandler OnUnitCasting;

    [SerializeField] private Transform meteorprefab;

    private void Update()
    {
        if (!isActive)
            return;


    }

    public override string GetActionName()
    {
        return "Meteor";
    }

    public override void TakeAction(Action onActionComplete)
    {
        Transform meteorTransform = Instantiate(meteorprefab, UnitActionSystem.Instance.GetSelectedEnemyUnit().transform.position, Quaternion.identity);
        MeteorVFX meteorVFX = meteorTransform.GetComponent<MeteorVFX>();
        meteorVFX.SetUp(OnGrenadeBehaviorComplete);

        OnUnitCasting?.Invoke(this, EventArgs.Empty);
        ActionStart(onActionComplete);
    }

    private void OnGrenadeBehaviorComplete()
    {
        ActionComplete();
    }

}
