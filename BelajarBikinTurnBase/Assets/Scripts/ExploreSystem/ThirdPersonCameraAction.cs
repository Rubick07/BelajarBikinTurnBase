using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraAction : MonoBehaviour
{
    private void Start()
    {
        MarketUI.instance.OnShopUIClose += MarketUI_OnShopUIClose;
        MarketUI.instance.OnShopUIOpen += MarketUI_OnShopUIOpen;

        PauseSystem.instance.OnGamePause += PauseSystem_OnGamePause;
        PauseSystem.instance.OnGameUnPause += PauseSystem_OnGameUnPause;
    }

    private void PauseSystem_OnGameUnPause(object sender, EventArgs e)
    {
        ThirdPersonCamera.instance.Show();
    }

    private void PauseSystem_OnGamePause(object sender, EventArgs e)
    {
        ThirdPersonCamera.instance.Hide();
    }

    private void MarketUI_OnShopUIOpen(object sender, EventArgs e)
    {
        ThirdPersonCamera.instance.Hide();
    }

    private void MarketUI_OnShopUIClose(object sender, EventArgs e)
    {
        ThirdPersonCamera.instance.Show();
    }
}
