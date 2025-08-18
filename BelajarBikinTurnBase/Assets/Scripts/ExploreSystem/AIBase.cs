using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBase : MonoBehaviour
{
    [SerializeField] protected float enemySpeed;
    protected float enemySpeedTemp;
    protected FieldOfView fieldOfView;
    protected UnityEngine.AI.NavMeshAgent agent;
    protected bool ngejerPlayer;

    public virtual void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        fieldOfView = GetComponent<FieldOfView>();

        enemySpeedTemp = enemySpeed;
        agent.speed = enemySpeed;
    }

    public void PhoneIsActive()
    {
        ngejerPlayer = true;
    }

    public void PlayerKabur()
    {
        ngejerPlayer = false;
    }

}
