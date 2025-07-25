using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Awake()
    {
        if (TryGetComponent<AttackAction>(out AttackAction attackAction))
        {
            attackAction.OnStartMoving += MoveAction_OnStartMoving;
            attackAction.OnStopMoving += MoveAction_OnStopMoving;

            attackAction.OnSwordActionStarted += AttackAction_OnSwordActionStarted;
            attackAction.OnSwordActionCompleted += AttackAction_OnSwordActionCompleted;

        }

    }

    private void AttackAction_OnSwordActionCompleted(object sender, System.EventArgs e)
    {

    }

    private void AttackAction_OnSwordActionStarted(object sender, System.EventArgs e)
    {
        animator.SetTrigger("SwordSlash");
    }

    private void MoveAction_OnStopMoving(object sender, System.EventArgs e)
    {
        animator.SetBool("IsWalking", false);
    }

    private void MoveAction_OnStartMoving(object sender, System.EventArgs e)
    {
        animator.SetBool("IsWalking", true);
    }
}
