using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketUIAction : MonoBehaviour
{
    private void Start()
    {
        MarketUI.instance.OnShopUIClose += MarketUI_OnShopUIClose;
        MarketUI.instance.OnShopUIOpen += MarketUI_OnShopUIOpen;
    }

    private void MarketUI_OnShopUIOpen(object sender, System.EventArgs e)
    {
        InputManager.Instance.GetInputActions().Player.Disable();
        ThirdPersonCamera.instance.Hide();
    }

    private void MarketUI_OnShopUIClose(object sender, System.EventArgs e)
    {
        InputManager.Instance.GetInputActions().Player.Enable();
        ThirdPersonCamera.instance.Show();
    }
}
