using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private EnemyAIPatrol enemyAIPatrol;

    private void Awake()
    {
        enemyAIPatrol = GetComponent<EnemyAIPatrol>();
    }

    private void Update()
    {
        if(enemyAIPatrol.GetAiState() == EnemyAIPatrol.AiState.IDLE)
        {
            animator.SetBool("IsWalking", false);
        }
        else
        {
            animator.SetBool("IsWalking", true);
        }
    }
}
