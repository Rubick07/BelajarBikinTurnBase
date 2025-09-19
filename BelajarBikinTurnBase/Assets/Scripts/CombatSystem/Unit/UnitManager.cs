using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance { get; private set; }

    public event EventHandler OnEnemyUnitListEmpty;
    public event EventHandler OnFriendlyUnitListEmpty;

    private List<Unit> unitList;
    private List<Unit> unitSortList;
    private List<Unit> friendlyUnitList;
    private List<Unit> enemyUnitList;

    private void Awake()
    {
        Instance = this;

        unitList = new List<Unit>();
        unitSortList = new List<Unit>();
        friendlyUnitList = new List<Unit>();
        enemyUnitList = new List<Unit>();
    }

    private void Start()
    {
        Unit.OnAnyUnitSpawned += Unit_OnAnyUnitSpawned;
        Unit.OnAnyUnitDead += Unit_OnAnyUnitDead;
    }

    private void Unit_OnAnyUnitSpawned(object sender, EventArgs e)
    {
        Unit unit = sender as Unit;

        unitList.Add(unit);

        if (unit.IsEnemy())
        {
            enemyUnitList.Add(unit);
            SortEnemyUnitList();
        }
        else
        {
            friendlyUnitList.Add(unit);
        }

        SortUnitList();
    }

    private void Unit_OnAnyUnitDead(object sender, EventArgs e)
    {
        Unit unit = sender as Unit;

        unitList.Remove(unit);

        if (unit.IsEnemy())
        {
            enemyUnitList.Remove(unit);
            
            if(enemyUnitList.Count == 0)
            {
                GameManager.instance.SetCombatState(GameManager.CombatState.Over);
                OnEnemyUnitListEmpty?.Invoke(this, EventArgs.Empty);
            }

        }
        else
        {
            friendlyUnitList.Remove(unit);

            if(friendlyUnitList.Count == 0)
            {
                GameManager.instance.SetCombatState(GameManager.CombatState.Over);
                OnFriendlyUnitListEmpty?.Invoke(this, EventArgs.Empty);
            }

        }

        SortUnitList();
    }

    private void SortUnitList()
    {
        unitSortList = unitList;
        unitSortList.Sort((a,b) => b.GetSpeed().CompareTo(a.GetSpeed()));
    }

    private void SortEnemyUnitList()
    {
        enemyUnitList.Sort((a, b) => b.transform.position.x.CompareTo(a.transform.position.x));
    }

    public List<Unit> GetUnitList()
    {
        return unitList;
    }

    public List<Unit> GetUnitSortList()
    {
        return unitSortList;
    }

    public List<Unit> GetFriendlyUnitList()
    {
        return friendlyUnitList;
    }

    public List<Unit> GetEnemyUnitList()
    {
        return enemyUnitList;
    }

    public int GetUnitListCount()
    {
        return unitList.Count;
    }

    public int GetEnemyUnitListCount()
    {
        return enemyUnitList.Count;
    }

    public int GetFriendlyUnitListCount()
    {
        return friendlyUnitList.Count;
    }

    public Unit GetEnemyUnitFromIndex(int index)
    {
        return enemyUnitList[index];
    }

    public Unit GetFriendlyUnitFromIndex(int index)
    {
        return friendlyUnitList[index];
    }

    public Unit GetRandomFriendlyUnit()
    {
        int choice = UnityEngine.Random.Range(0, friendlyUnitList.Count);

        return friendlyUnitList[choice];
    }


}
