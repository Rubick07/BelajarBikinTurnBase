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
            UnPause();
        }
        else
        {
            //Pause
            Pause();
        }

    }

    public void UnPause()
    {
        pauseState = PauseState.UnPause;
        OnGameUnPause?.Invoke(this, EventArgs.Empty);
    }

    public void Pause()
    {
        pauseState = PauseState.Pause;
        OnGamePause?.Invoke(this, EventArgs.Empty);
    }

    public PauseState GetPauseState()
    {
        return pauseState;
    }

}
