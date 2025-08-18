using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform footPositionTransform;
    [SerializeField] private Transform shootPointTransform;
    [SerializeField] private Transform fireballPrefab;
    [SerializeField] private Transform curseCirclePrefab;
    [SerializeField] private Transform magicCirclePrefab;
    private void Awake()
    {
        if(TryGetComponent<HealthSystem>(out HealthSystem healthSystem))
        {
            healthSystem.OnDamaged += HealthSystem_OnDamaged;
        }

        if (TryGetComponent<AttackAction>(out AttackAction attackAction))
        {
            attackAction.OnStartMoving += MoveAction_OnStartMoving;
            attackAction.OnStopMoving += MoveAction_OnStopMoving;

            attackAction.OnSwordActionStarted += AttackAction_OnSwordActionStarted;
            attackAction.OnSwordActionCompleted += AttackAction_OnSwordActionCompleted;

        }

        if (TryGetComponent<CurseSkillAction>(out CurseSkillAction curseSkillAction))
        {
            curseSkillAction.OnUnitChanting += CurseSkillAction_OnUnitChanting;
            curseSkillAction.OnUnitSpellCasted += CurseSkillAction_OnUnitSpellCasted;
        }

        if (TryGetComponent<FireballAction>(out FireballAction fireballSkillAction))
        {
            fireballSkillAction.OnUnitChanting += FireballSkillAction_OnUnitChanting;
            fireballSkillAction.OnUnitSpellCasted += FireballSkillAction_OnUnitSpellCasted;
        }

        if (TryGetComponent<MeteorAction>(out MeteorAction meteorAction))
        {
            meteorAction.OnUnitCasting += MeteorAction_OnUnitCasting;
        }

    }

    private void MeteorAction_OnUnitCasting(object sender, System.EventArgs e)
    {
        animator.SetTrigger("Casting");
        Transform magicCircleTransform = Instantiate(magicCirclePrefab, footPositionTransform);
        Destroy(magicCircleTransform.gameObject, 1.2f);
    }

    private void FireballSkillAction_OnUnitSpellCasted(object sender, Unit targetUnit)
    {
        Transform fireballTransform = Instantiate(fireballPrefab, shootPointTransform);
        fireballTransform.parent = null;

        BulletProjectile bulletProjectile = fireballTransform.GetComponent<BulletProjectile>();

        bulletProjectile.Setup(targetUnit.transform.position);

    }

    private void FireballSkillAction_OnUnitChanting(object sender, System.EventArgs e)
    {
        animator.SetTrigger("Casting");
        Transform magicCircleTransform = Instantiate(magicCirclePrefab, footPositionTransform);
        Destroy(magicCircleTransform.gameObject, 1.2f);
    }

    private void CurseSkillAction_OnUnitSpellCasted(object sender, System.EventArgs e)
    {
        Transform curseCircleTransform = Instantiate(curseCirclePrefab, UnitActionSystem.Instance.GetSelectedEnemyUnit().transform);

        curseCirclePrefab.position = Vector3.zero;

        Destroy(curseCircleTransform.gameObject, 1.5f);
    }

    private void CurseSkillAction_OnUnitChanting(object sender, System.EventArgs e)
    {
        animator.SetTrigger("Casting");
        Transform magicCircleTransform = Instantiate(magicCirclePrefab, footPositionTransform);
        Destroy(magicCircleTransform.gameObject, 1.2f);

    }

    private void HealthSystem_OnDamaged(object sender, System.EventArgs e)
    {
        animator.SetTrigger("damaged");
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
