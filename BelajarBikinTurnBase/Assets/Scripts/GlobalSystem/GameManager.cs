using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public event EventHandler OnSceneChanged;
    public event EventHandler<CombatState> OnCombatStateChanged;

    public enum SceneState
    {
        City,
        Explore,
        Combat
    }

    public enum CombatState
    {
        Start,
        Battle,
        Over
    }

    [SerializeField] private SceneState sceneState;
    [SerializeField] private CombatState combatState;

    [Header("PartSO Reference")]
    [SerializeField] private PlayerPartySO playerPartySO;
    [SerializeField] private EnemyPartySO enemyPartySO;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }

    public void SetEnemyPartySO(EnemyPartySO enemyPartySO)
    {
        this.enemyPartySO = enemyPartySO;
    }

    #region CombatScene

    public void SetCombatState(CombatState combatState)
    {
        this.combatState = combatState;

        OnCombatStateChanged?.Invoke(this, combatState);
    }


    #endregion


}
