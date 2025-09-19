using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Start()
    {
        PauseSystem.instance.OnGamePause += PauseSystem_OnGamePause;
        PauseSystem.instance.OnGameUnPause += PauseSystem_OnGameUnPause;
    }

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

    private void PauseSystem_OnGameUnPause(object sender, System.EventArgs e)
    {
        this.enabled = true;
    }

    private void PauseSystem_OnGamePause(object sender, System.EventArgs e)
    {
        animator.SetBool("IsWalking", false);
        this.enabled = false;
    }


}
