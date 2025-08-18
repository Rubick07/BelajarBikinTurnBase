#define USE_NEW_INPUT_SYSTEM
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    private InputSystem_Actions playerInputActions;

    private void Awake()
    {
        Instance = this;

        playerInputActions = new InputSystem_Actions();
        playerInputActions.Player.Enable();

    }

    public Vector2 GetMouseScreenPosition()
    {
#if USE_NEW_INPUT_SYSTEM
        return Mouse.current.position.ReadValue();
#else
    return Input.mousePosition;
#endif
    }

    public bool IsMouseButtonDownThisFrame()
    {
#if USE_NEW_INPUT_SYSTEM
        return playerInputActions.Player.Click.WasPressedThisFrame();
#else
        return Input.GetMouseButtonDown(0);
#endif
    }

    public bool IsKeyboardQPressed()
    {
#if USE_NEW_INPUT_SYSTEM
        return playerInputActions.Player.Attack.WasPressedThisFrame();
#else
        return Input.GetKeyDown(KeyCode.Q);;
#endif
    }

    public bool IsLeftArrowPressed()
    {
#if USE_NEW_INPUT_SYSTEM
        return playerInputActions.Player.LeftArrow.WasPressedThisFrame();
#else
        return Input.GetKeyDown(KeyCode.LeftArrow);;
#endif
    }

    public bool IsRightArrowPressed()
    {
#if USE_NEW_INPUT_SYSTEM
        return playerInputActions.Player.RightArrow.WasPressedThisFrame();
#else
        return Input.GetKeyDown(KeyCode.RightArrow);;
#endif
    }

    public bool IsUpArrowPressed()
    {
#if USE_NEW_INPUT_SYSTEM
        return playerInputActions.Player.UpArrow.WasPressedThisFrame();
#else
        return Input.GetKeyDown(KeyCode.UpArrow);;
#endif
    }

    public bool IsDownArrowPressed()
    {
#if USE_NEW_INPUT_SYSTEM
        return playerInputActions.Player.DownArrow.WasPressedThisFrame();
#else
        return Input.GetKeyDown(KeyCode.DownArrow);;
#endif
    }

    public bool Is1KeyPressed()
    {
#if USE_NEW_INPUT_SYSTEM
        return playerInputActions.Player._1.WasPressedThisFrame();
#else
        return Input.GetKeyDown(KeyCode.1);;
#endif
    }


    public bool IsKeyboardWPressed()
    {
#if USE_NEW_INPUT_SYSTEM
        return playerInputActions.Player.W.WasPressedThisFrame();
#else
        return Input.GetKeyDown(KeyCode.W);;
#endif
    }

    public bool IsKeyboardEnterPressed()
    {
#if USE_NEW_INPUT_SYSTEM
        return playerInputActions.Player.Enter.WasPressedThisFrame();
#else
        return Input.GetKeyDown(KeyCode.Enter);;
#endif
    }

    public Vector2 GetMoveInputValue()
    {
        return playerInputActions.Player.Move.ReadValue<Vector2>();
    }

}
