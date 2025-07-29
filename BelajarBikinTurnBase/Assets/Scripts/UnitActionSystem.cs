using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class UnitActionSystem : MonoBehaviour
{
    private enum State
    {
        SelectAction,
        SelectMagic,
        SelectEnemy
    }

    private State state;

    public static UnitActionSystem Instance { get; private set; }

    public event EventHandler OnStateChanged;

    public event EventHandler OnSelectedUnitChanged;
    public event EventHandler OnSelectedSkillActionChanged;

    public event EventHandler OnSelectedEnemyUnitChanged;

    public event EventHandler<bool> OnBusyChanged;
    public event EventHandler OnActionStarted;

    [SerializeField] private Unit selectedUnit;
    [SerializeField] private LayerMask unitLayerMask;

    private SkillAction currentSkillAction;

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

        TurnSystem.Instance.OnUnitTurnChanged += TurnSystem_OnUnitTurnChanged;
    }

    private void Update()
    {
        if (isBusy)
            return;

        if (!TurnSystem.Instance.IsCurrentPlayerTurn()) 
            return;

        switch (state)
        {
            case State.SelectAction:
                HandleSelectEnemyUnit();
                HandleSelectedUnitAction();
                break;
            case State.SelectMagic:
                HandleSelectSkillAction();
                break;

            case State.SelectEnemy:
                HandleSelectEnemyUnit();
                break;


        }

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

            selectedUnit.GetAction<AttackAction>().TakeAction(ClearBusy);

            OnActionStarted?.Invoke(this, EventArgs.Empty);
        }

        if (InputManager.Instance.IsKeyboardWPressed())
        {
            if (selectedUnit.GetSkillActionListCount() == 0)
                return;

            state = State.SelectMagic;

            OnStateChanged?.Invoke(this, EventArgs.Empty);
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

        if (IsSelectEnemy())
        {
            if (InputManager.Instance.IsKeyboardEnterPressed())
            {
                state = State.SelectAction;
                SetBusy();
                currentSkillAction.TakeAction(ClearBusy);
            }
        }
    }

    private void HandleSelectSkillAction()
    {
        if (InputManager.Instance.IsDownArrowPressed())
        {
            SetCurrentSkill();

        }
        if (InputManager.Instance.IsUpArrowPressed())
        {
            SetCurrentSkill();
        }
        if (InputManager.Instance.Is1KeyPressed())
        {
            state = State.SelectAction;

            OnStateChanged?.Invoke(this, EventArgs.Empty);
        }
        if (InputManager.Instance.IsKeyboardEnterPressed())
        {
            state = State.SelectEnemy;

            OnStateChanged?.Invoke(this, EventArgs.Empty);
        }

    }

    private void SetCurrentSkill()
    {
        SkillAction skillAction = EventSystem.current.currentSelectedGameObject.GetComponent<UnitSkillButtonUI>().GetThisBaseSkillButton();
        currentSkillAction = skillAction;

        OnSelectedSkillActionChanged?.Invoke(this, EventArgs.Empty);

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

    public bool IsSelectAction()
    {
        return state == State.SelectAction;
    }

    public bool IsSelectEnemy()
    {
        return state == State.SelectEnemy;
    }

    public bool IsSelectMagic()
    {
        return state == State.SelectMagic;
    }

    public SkillAction GetSkillAction()
    {
        return currentSkillAction;
    }

    private void TurnSystem_OnUnitTurnChanged(object sender, EventArgs e)
    {
        if (TurnSystem.Instance.IsCurrentPlayerTurn())
            selectedUnit = TurnSystem.Instance.GetCurrentUnit();

    }

}
