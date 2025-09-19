using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUIController : MonoBehaviour
{
    private void Start()
    {
        PauseSystem.instance.OnGamePause += PauseSystem_OnGamePause;
        PauseSystem.instance.OnGameUnPause += PauseSystem_OnGameUnPause;
    }

    private void PauseSystem_OnGameUnPause(object sender, System.EventArgs e)
    {
        InputManager.Instance.GetInputActions().Player.Escape.performed -= Escape_performed;
    }

    private void PauseSystem_OnGamePause(object sender, System.EventArgs e)
    {
        InputManager.Instance.GetInputActions().Player.Escape.performed += Escape_performed;
    }

    private void Escape_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if(PauseUI.instance.GetState() == PauseUI.State.MainMenu)
        {
            PauseSystem.instance.UnPause();
        }
        else if(PauseUI.instance.GetState() == PauseUI.State.InventoryMenu)
        {
            PauseUI.instance.SetState(PauseUI.State.MainMenu);
        }
        else
        {
            PauseUI.instance.SetState(PauseUI.State.InventoryMenu);
        }
    }
}
