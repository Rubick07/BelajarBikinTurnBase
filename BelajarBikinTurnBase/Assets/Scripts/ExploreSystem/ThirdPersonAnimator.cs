using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Update()
    {
        float horizontal = InputManager.Instance.GetMoveInputValue().x;
        float vertical = InputManager.Instance.GetMoveInputValue().y;

        if (horizontal != 0 || vertical != 0)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }


}
