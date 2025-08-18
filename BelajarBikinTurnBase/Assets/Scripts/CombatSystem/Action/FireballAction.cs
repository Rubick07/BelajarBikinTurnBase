using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAction : SkillAction
{
    private enum State
    {
        Chanting,
        SpellCasted,
        CoolOff
    }

    public event EventHandler OnUnitChanting;
    public event EventHandler<Unit> OnUnitSpellCasted;

    private bool canShoot = false;

    private float stateTimer;
    private State state;

    private Unit targetUnit;
    private void Update()
    {
        if (!isActive)
            return;

        stateTimer -= Time.deltaTime;

        switch (state)
        {
            case State.Chanting:
                Vector3 targetPosition = targetUnit.transform.position;
                Vector3 rotateDirection = (targetPosition - transform.position).normalized;

                float rotateSpeed = 10f;
                transform.forward = Vector3.Lerp(transform.forward, rotateDirection, Time.deltaTime * rotateSpeed);

                break;
            case State.SpellCasted:
                if (canShoot)
                {
                    OnUnitSpellCasted?.Invoke(this, targetUnit);

                    canShoot = false;
                }

                break;
            case State.CoolOff:

                break;
        }

        if (stateTimer <= 0)
            NextState();


    }

    private void NextState()
    {
        switch (state)
        {
            case State.Chanting:
                state = State.SpellCasted;
                float spellCastedTimer = .5f;
                stateTimer = spellCastedTimer;

                break;
            case State.SpellCasted:
                state = State.CoolOff;
                float coolOffStateTimer = .5f;
                stateTimer = coolOffStateTimer;
                break;
            case State.CoolOff:
                targetUnit.GetHealthSystem().Damage(90);
                ActionComplete();
                break;
        }
    }


    public override string GetActionName()
    {
        return "Fireball";
    }

    public override void TakeAction(Action onActionComplete)
    {
        state = State.Chanting;

        if (GetUnit().IsEnemy())
        {

            targetUnit = UnitManager.Instance.GetRandomFriendlyUnit();
        }
        else
        {
            targetUnit = UnitActionSystem.Instance.GetSelectedEnemyUnit();
        }

        float chantingStateTimer = 1.8f;
        stateTimer = chantingStateTimer;

        canShoot = true;

        OnUnitChanting?.Invoke(this, EventArgs.Empty);


        ActionStart(onActionComplete);
    }

    public override EnemyAIAction GetEnemyAIAction()
    {
        return new EnemyAIAction
        {
            actionValue = 1
        };
    }
}
