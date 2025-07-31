using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChantingVFX : MonoBehaviour
{

    private void Start()
    {
        UnitActionSystem.Instance.OnStateChanged += UnitActionSystem_OnStateChanged;
        Hide();
    }

    private void UnitActionSystem_OnStateChanged(object sender, System.EventArgs e)
    {
        if (UnitActionSystem.Instance.IsSelectMagic())
        {
            transform.position = UnitActionSystem.Instance.GetCurrentSelectedUnit().transform.position;
            transform.position = new Vector3(transform.position.x ,0 , transform.position.z);
            Show();
        }
        else
        {
            Hide();
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
