using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    [SerializeField] private GameObject actionCameraGameObject;
    private UnitCameraPosition currentCamera;
    private List<UnitCameraPosition> unitCameraPositionList;

    private void Awake()
    {
        instance = this;
        unitCameraPositionList = new List<UnitCameraPosition>();
    }

    private void Start()
    {
        TurnSystem.Instance.OnUnitTurnChanged += TurnSystem_OnUnitTurnChanged;

        UnitActionSystem.Instance.OnStateChanged += UnitActionSystem_OnStateChanged;

        HideActionCamera();
    }

    private void UnitActionSystem_OnStateChanged(object sender, EventArgs e)
    {
        if (UnitActionSystem.Instance.IsSelectMagic())
        {
            Vector3 currentCameraPosition = currentCamera.transform.position;

            Vector3 offset = new Vector3(-1.3f, 1, -2f);

            actionCameraGameObject.transform.position = currentCameraPosition + offset;

            ShowActionCamera();
        }
        else
        {
            HideActionCamera();
        }
    }

    private void ShowActionCamera()
    {
        actionCameraGameObject.SetActive(true);
    }

    private void HideActionCamera()
    {
        actionCameraGameObject.SetActive(false);
    }

    private void TurnSystem_OnUnitTurnChanged(object sender, EventArgs e)
    {
        currentCamera.Hide();
        if (TurnSystem.Instance.IsCurrentPlayerTurn())
        {
            foreach(UnitCameraPosition unitCameraPosition in unitCameraPositionList)
            {
                if(unitCameraPosition.GetUnit() == TurnSystem.Instance.GetCurrentUnit())
                {
                    currentCamera = unitCameraPosition;
                    unitCameraPosition.Show();
                    return;
                }
            }


        }
        else
        {
            HideActionCamera();
        }
    }

    public void AddCameraToList(UnitCameraPosition unitCameraPosition)
    {
        currentCamera = unitCameraPosition;
        unitCameraPositionList.Add(unitCameraPosition);
    }

    public void RemoveCameraFromList(UnitCameraPosition unitCameraPosition)
    {
        unitCameraPositionList.Remove(unitCameraPosition);
    }

}
