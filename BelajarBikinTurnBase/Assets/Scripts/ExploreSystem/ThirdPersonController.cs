using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public static ThirdPersonController instance;

    [SerializeField] private float speed = 6f;
    [SerializeField] private Transform cam;

    private CharacterController characterController;

    private float turnSmoothTime = .1f;
    float turnSmoothVelocity;
    Vector3 gravity;

    private bool isFloating;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        //Cursor.lockState = CursorLockMode.Locked;

        instance = this;
    }

    private void Start()
    {
        //InputManager.instance.GetInputActions().Player.Jump.performed += Jump_performed;
        ActionSetUp();

        PauseSystem.instance.OnGamePause += PauseSystem_OnGamePause;
        PauseSystem.instance.OnGameUnPause += PauseSystem_OnGameUnPause;

    }

    private void Update()
    {
        float horizontal = InputManager.Instance.GetMoveInputValue().x;
        float vertical = InputManager.Instance.GetMoveInputValue().y;

        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);



            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            characterController.Move(moveDir * speed * Time.deltaTime);

        }

        if (!characterController.isGrounded && !isFloating)
        {
            gravity += Physics.gravity * Time.deltaTime;
        }

        characterController.Move(gravity * speed * Time.deltaTime);
    }

    public void SetIsFloating(bool isFloating)
    {
        this.isFloating = isFloating;
        gravity.y = 2f;
    }

    public void FloatingMaxHeight()
    {
        gravity.y = 0f;
    }

    private void ActionSetUp()
    {
        InputManager.Instance.GetInputActions().Player.Interact.performed += Interact_performed;
        InputManager.Instance.GetInputActions().Player.Escape.performed += Escape_performed;
    }

    private void ActionDisable()
    {
        InputManager.Instance.GetInputActions().Player.Interact.performed -= Interact_performed;
        InputManager.Instance.GetInputActions().Player.Escape.performed -= Escape_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        InteractSystem.instance.InteractCheck();
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        gravity.y = 5f;
    }

    private void Escape_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if(PauseSystem.instance.GetPauseState() == PauseSystem.PauseState.UnPause)
        {
            PauseSystem.instance.Pause();
        }
    }
    private void PauseSystem_OnGameUnPause(object sender, System.EventArgs e)
    {
        ActionSetUp();
        this.enabled = true;
    }

    private void PauseSystem_OnGamePause(object sender, System.EventArgs e)
    {
        ActionDisable();
        this.enabled = false;
    }

}
