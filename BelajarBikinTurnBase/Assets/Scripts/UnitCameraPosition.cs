using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCameraPosition : MonoBehaviour
{
    [SerializeField] private Unit unit;

    private void Start()
    {
        CameraManager.instance.AddCameraToList(this);
        Hide();
    }

    public Unit GetUnit()
    {
        return unit;
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
