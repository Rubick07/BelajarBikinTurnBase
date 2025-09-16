using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PauseSystem : MonoBehaviour
{
    public static PauseSystem instance;

    public event EventHandler OnGamePause;
    public event EventHandler OnGameUnPause;

    public enum PauseState
    {
        Pause,
        UnPause
    }

    private PauseState pauseState = PauseState.UnPause;

    private void Awake()
    {
        instance = this;
    }

    public void TogglePause()
    {
        if (pauseState == PauseState.Pause)
        {
            //Mulai
            pauseState = PauseState.UnPause;

            Cursor.lockState = CursorLockMode.Locked;

            OnGameUnPause?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            //Pause
            pauseState = PauseState.Pause;
            Cursor.lockState = CursorLockMode.None;
            OnGamePause?.Invoke(this, EventArgs.Empty);
        }

    }
}
