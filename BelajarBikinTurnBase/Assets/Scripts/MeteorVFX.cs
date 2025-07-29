using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MeteorVFX : MonoBehaviour
{
    public static event EventHandler OnAnyGrenadeExploded;

    private Vector3 targetPosition;
    private Action OnGrenadeBehaviourComplete;
    private float timer;

    private void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0f)
        {
            float damageRadius = 4f;
            Collider[] colliderArray = Physics.OverlapSphere(targetPosition, damageRadius);

            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent<Unit>(out Unit targetUnit))
                {
                    targetUnit.GetHealthSystem().Damage(40);
                }


            }

            OnAnyGrenadeExploded?.Invoke(this, EventArgs.Empty);

            Destroy(gameObject);

            OnGrenadeBehaviourComplete();
        }
    }

    public void SetUp(Action OnGrenadeBehaviourComplete)
    {
        this.OnGrenadeBehaviourComplete = OnGrenadeBehaviourComplete;

        targetPosition = UnitActionSystem.Instance.GetSelectedEnemyUnit().transform.position;

        timer = 1.5f;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(targetPosition, 4f);
    }

}
