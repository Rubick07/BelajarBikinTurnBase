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

}
