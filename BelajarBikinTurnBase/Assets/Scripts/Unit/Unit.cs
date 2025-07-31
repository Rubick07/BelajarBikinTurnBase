using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Unit : MonoBehaviour
{
    [SerializeField] private Sprite unitImage;
    [SerializeField] private int speed;
    [SerializeField] private bool isEnemy;

    public static event EventHandler OnAnyUnitSpawned;
    public static event EventHandler OnAnyUnitDead;
    private BaseAction[] baseActionArray;
    private HealthSystem healthSystem;
    private ManaSystem manaSystem;
    private void Awake()
    {
        baseActionArray = GetComponents<BaseAction>();
        healthSystem = GetComponent<HealthSystem>();
        manaSystem = GetComponent<ManaSystem>();
    }

    private void Start()
    {
        healthSystem.OnDead += HealthSystem_OnDead;
        OnAnyUnitSpawned?.Invoke(this, EventArgs.Empty);
    }

    private void HealthSystem_OnDead(object sender, EventArgs e)
    {
        UnitActionSystem.Instance.SetTargetEnemy(0);

        Destroy(gameObject);
        
        OnAnyUnitDead?.Invoke(this, EventArgs.Empty);
    }

    public bool IsEnemy()
    {
        return isEnemy;
    }

    public int GetSpeed()
    {
        return speed;
    }

    public T GetAction<T>() where T : BaseAction
    {
        foreach (BaseAction baseAction in baseActionArray)
        {
            if (baseAction is T)
            {
                return (T)baseAction;
            }
        }
        return null;
    }

    public HealthSystem GetHealthSystem()
    {
        return healthSystem;
    }

    public ManaSystem GetManaSystem()
    {
        return manaSystem;
    }

    public Sprite GetUnitImage()
    {
        return unitImage;
    }
    public BaseAction[] GetBaseActionArray()
    {
        return baseActionArray;
    }

    public List<SkillAction> GetSkillActionList()
    {
        List<SkillAction> skillActionList = new List<SkillAction>();

        foreach(BaseAction baseAction in baseActionArray)
        {
            if(baseAction is SkillAction)
            {
                SkillAction skillAction = (SkillAction)baseAction;
                skillActionList.Add(skillAction);
            }
        }

        return skillActionList;
    }

    public int GetSkillActionListCount()
    {
        List<SkillAction> skillActionList = new List<SkillAction>();

        foreach (BaseAction baseAction in baseActionArray)
        {
            if (baseAction is SkillAction)
            {
                SkillAction skillAction = (SkillAction)baseAction;
                skillActionList.Add(skillAction);
            }
        }

        return skillActionList.Count;
    }

    public bool TrySpendActionPointsToTakeAction(BaseAction baseAction)
    {
        if (CanSpendSkillToTakeSkillAction(baseAction))
        {
            SpendsActionPoints(baseAction.GetSkillCost());
            return true;
        }
        else return false;
    }

    public bool CanSpendSkillToTakeSkillAction(BaseAction baseAction)
    {
        return manaSystem.GetMana() >= baseAction.GetSkillCost();
    }

    private void SpendsActionPoints(int amount)
    {
        manaSystem.ConsumeMana(amount);
    }


}
