using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolPoint : MonoBehaviour
{
    [SerializeField] private List<Transform> patrolTransformList;

    public List<Transform> GetTransformList()
    {
        return patrolTransformList;
    }
}
