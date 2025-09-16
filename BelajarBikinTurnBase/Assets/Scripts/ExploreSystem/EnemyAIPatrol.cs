using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyAIPatrol : AIBase
{
    public enum AiState
    {
        IDLE,
        CHASE,
        PATROL
    }

    [SerializeField] private AiState enemyState;
    [SerializeField] private float chaseSpeed;
    [SerializeField] private float timeToLosingSight;
    [SerializeField] private EnemyPatrolPoint patrolPoint;
    private float timeToLosingSightTemp;
    private List<Transform> enemyPatrolTransformList;
    private Transform targetTransform;

    private int index;

    public override void Awake()
    {
        base.Awake();
        timeToLosingSightTemp = timeToLosingSight;
    }

    public void Start()
    {
        enemyPatrolTransformList = patrolPoint.GetTransformList();
        GoToNextPatrolPoint();
    }

    private void Update()
    {
        if (ngejerPlayer)
        {
            ChaseMode();
            return;
        }

        if (fieldOfView.canSeeTarget)
        {
            ChaseMode();
            return;
        }

        if (!fieldOfView.canSeeTarget && enemyState == AiState.CHASE)
        {
            timeToLosingSight -= Time.deltaTime;
            agent.SetDestination(fieldOfView.targetRef.transform.position);
            if (timeToLosingSight <= 0)
            {
                GoToNextPatrolPoint();
            }

            return;
        }

        PatrolMode();
    }

    private void PatrolMode()
    {
        agent.SetDestination(targetTransform.position + new Vector3(0, 0, 1f));
        //Nyampe
        if (Vector3.Distance(transform.position, targetTransform.position) <= agent.stoppingDistance)
        {
            GoToNextPatrolPoint();
        }
    }

    private void ChaseMode()
    {
        enemyState = AiState.CHASE;
        timeToLosingSight = timeToLosingSightTemp;
        agent.speed = chaseSpeed;
        agent.SetDestination(InputManager.Instance.transform.position);
    }

    private void GoToNextPatrolPoint()
    {
        enemyState = AiState.PATROL;
        agent.speed = enemySpeed;

        if(index > enemyPatrolTransformList.Count)
        {
            index = 0;
        }
        else
        {
            index++;
        }

        targetTransform = enemyPatrolTransformList[index];
        agent.SetDestination(enemyPatrolTransformList[index].position + new Vector3(0, 0, 1f));
    }

    public AiState GetAiState()
    {
        return enemyState;
    }

}
