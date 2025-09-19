using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurnSystem : MonoBehaviour
{
    public static TurnSystem Instance { get; private set; }

    public event EventHandler OnTurnChanged;
    public event EventHandler OnUnitTurnChanged;


    [SerializeField] Unit currentUnitTurn;
    private int turnNumber = 1;
    private int currentUnitCount = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameManager.instance.OnCombatStateChanged += GameManager_OnCombatStateChanged;
    }

    public void StartTurn()
    {
        currentUnitTurn = UnitManager.Instance.GetUnitSortList()[0];

        OnUnitTurnChanged?.Invoke(this, EventArgs.Empty);
    }

    public void NextUnitOnCurrentTurn()
    {
        currentUnitCount++;
        if (currentUnitCount >= UnitManager.Instance.GetUnitListCount())
            NextTurn();

        List<Unit> test = UnitManager.Instance.GetUnitSortList();
        currentUnitTurn = test[currentUnitCount];
        OnUnitTurnChanged?.Invoke(this, EventArgs.Empty);
    }

    public void NextTurn()
    {
        currentUnitCount = 0;
        turnNumber++;
        OnTurnChanged?.Invoke(this, EventArgs.Empty);
    }


    private void GameManager_OnCombatStateChanged(object sender, GameManager.CombatState e)
    {
        if(e == GameManager.CombatState.Battle)
        {
            StartTurn();
        }
    }


    public int GetTurnNumber()
    {
        return turnNumber;
    }

    public Unit GetCurrentUnit()
    {
        return currentUnitTurn;
    }

    public bool IsCurrentPlayerTurn()
    {
        return !currentUnitTurn.IsEnemy();
    }

    private void OnDestroy()
    {
        GameManager.instance.OnCombatStateChanged -= GameManager_OnCombatStateChanged;
    }

}
