using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : BaseAction
{
    public event EventHandler OnStartMoving;
    public event EventHandler OnStopMoving;

    public event EventHandler OnSwordActionStarted;
    public event EventHandler OnSwordActionCompleted;

    private enum State
    {
        Walking,
        SwordSwing
    }

    private float stateTimer;

    private State state;
    private Vector3 positionBeforeAttack;
    private void Update()
    {
        if (!isActive)
            return;

        switch (state)
        {
            case State.Walking:
                Walk();
                break;

            case State.SwordSwing:
                Sword();
                break;

        }
    }

    private void Walk()
    {
        Vector3 targetPosition = UnitActionSystem.Instance.GetSelectedEnemyUnit().transform.position;
        targetPosition = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);

        Vector3 moveDirection = (targetPosition - transform.position).normalized;


        float rotateSpeed = 10f;
        transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);

        float moveSpeed = 4f;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        float stoppingDistance = 1.5f;
        if (Vector3.Distance(transform.position, targetPosition) < stoppingDistance)
        {
            stateTimer = 1.5f;

            state = State.SwordSwing;
            OnStopMoving?.Invoke(this, EventArgs.Empty);

            OnSwordActionStarted?.Invoke(this, EventArgs.Empty);
        }
    }

    private void Sword()
    {
        stateTimer -= Time.deltaTime;

        if(stateTimer <= 0)
        {
            transform.position = positionBeforeAttack;

            UnitActionSystem.Instance.GetSelectedEnemyUnit().GetHealthSystem().Damage(10);

            OnSwordActionCompleted?.Invoke(this, EventArgs.Empty);

            ActionComplete();
        }

    }

    public override string GetActionName()
    {
        return "Attack";
    }

    public override void TakeAction(Action onActionComplete)
    {
        state = State.Walking;

        positionBeforeAttack = transform.position;


        OnStartMoving?.Invoke(this, EventArgs.Empty);

        ActionStart(onActionComplete);
    }




}
