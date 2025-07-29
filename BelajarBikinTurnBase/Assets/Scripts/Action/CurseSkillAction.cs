using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurseSkillAction : SkillAction
{
    private enum State
    {
        Chanting,
        SpellCasted,
        CoolOff
    }

    public event EventHandler OnUnitChanting;
    public event EventHandler OnUnitSpellCasted;

    private bool canShoot = false;

    private float stateTimer;
    private State state;

    private void Update()
    {
        if (!isActive)
            return;

        stateTimer -= Time.deltaTime;

        switch (state)
        {
            case State.Chanting:
                Vector3 targetPosition = UnitActionSystem.Instance.GetSelectedEnemyUnit().transform.position;
                Vector3 moveDirection = (targetPosition - transform.position).normalized;

                float rotateSpeed = 10f;
                transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);

                break;
            case State.SpellCasted:
                if (canShoot)
                {
                    OnUnitSpellCasted?.Invoke(this, EventArgs.Empty);

                    UnitActionSystem.Instance.GetSelectedEnemyUnit().GetHealthSystem().Damage(90);

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
                ActionComplete();
                break;
        }
    }
    

    public override string GetActionName()
    {
        return "Curse";
    }

    public override void TakeAction(Action onActionComplete)
    {
        state = State.Chanting;
        float chantingStateTimer = 1.2f;
        stateTimer = chantingStateTimer;

        canShoot = true;

        OnUnitChanting?.Invoke(this, EventArgs.Empty);


        ActionStart(onActionComplete);
    }

}
