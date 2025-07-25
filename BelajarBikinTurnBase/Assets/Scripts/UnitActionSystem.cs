using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitActionSystem : MonoBehaviour
{
    public static UnitActionSystem Instance { get; private set; }

    public event EventHandler OnSelectedUnitChanged;
    public event EventHandler OnSelectedActionChanged;

    public event EventHandler OnSelectedEnemyUnitChanged;

    public event EventHandler<bool> OnBusyChanged;
    public event EventHandler OnActionStarted;

    [SerializeField] private Unit selectedUnit;
    [SerializeField] private LayerMask unitLayerMask;

    private Unit selectedEnemyUnit;
    private int selectedEnemyUnitIndex = 0;
    //private BaseAction selectedAction;
    private bool isBusy;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        selectedEnemyUnit = UnitManager.Instance.GetEnemyUnitFromIndex(0);
    }

    private void Update()
    {
        if (isBusy)
            return;

        if (!TurnSystem.Instance.IsCurrentPlayerTurn())
            return;

        HandleSelectEnemyUnit();
        HandleSelectedUnitAction();
    }

    private void SetBusy()
    {
        isBusy = true;
        OnBusyChanged?.Invoke(this, isBusy);
    }

    private void ClearBusy()
    {
        isBusy = false;

        TurnSystem.Instance.NextUnitOnCurrentTurn();

        OnBusyChanged?.Invoke(this, isBusy);
    }

    public Unit GetCurrentSelectedUnit()
    {
        return selectedUnit;
    }

    private void HandleSelectedUnitAction()
    {
        if (InputManager.Instance.IsKeyboardQPressed())
        {
            SetBusy();

            selectedUnit = TurnSystem.Instance.GetCurrentUnit();
            selectedUnit.GetAction<AttackAction>().TakeAction(ClearBusy);

            OnActionStarted?.Invoke(this, EventArgs.Empty);
        }
    }

    private void HandleSelectEnemyUnit()
    {
        if (InputManager.Instance.IsLeftArrowPressed())
        {
            ChangeTargetEnemy(1);
        }

        if (InputManager.Instance.IsRightArrowPressed())
        {
            ChangeTargetEnemy(-1);
        }
    }

    private void ChangeTargetEnemy(int change)
    {
        selectedEnemyUnitIndex += change;
        if(selectedEnemyUnitIndex == -1)
        {
            selectedEnemyUnitIndex = UnitManager.Instance.GetEnemyUnitListCount() -1;
        }
        if (selectedEnemyUnitIndex == UnitManager.Instance.GetEnemyUnitListCount())
        {
            selectedEnemyUnitIndex = 0;
        }

        selectedEnemyUnit = UnitManager.Instance.GetEnemyUnitFromIndex(selectedEnemyUnitIndex);

        OnSelectedEnemyUnitChanged?.Invoke(this, EventArgs.Empty);

    }

    public void SetTargetEnemy(int index)
    {

        selectedEnemyUnit = UnitManager.Instance.GetEnemyUnitFromIndex(index);

        OnSelectedEnemyUnitChanged?.Invoke(this, EventArgs.Empty);

    }

    public Unit GetSelectedEnemyUnit()
    {
        return selectedEnemyUnit;
    }

}
