using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CombatSYSTEM
{

    public class EnemyAI : MonoBehaviour
    {
        private enum State
        {
            WaitingForEnemyTurn,
            TakingTurn,
            Busy
        }

        private State state;
        private float timer;
        private bool alreadyUseAction;

        private void Awake()
        {
            state = State.WaitingForEnemyTurn;
        }

        private void Start()
        {
            TurnSystem.Instance.OnUnitTurnChanged += TurnSystem_OnUnitTurnChanged;
            GameManager.instance.OnCombatStateChanged += GameManager_OnCombatStateChanged;
        }

        private void Update()
        {
            if (TurnSystem.Instance.IsCurrentPlayerTurn())
                return;

            switch (state)
            {
                case State.WaitingForEnemyTurn:
                    break;
                case State.TakingTurn:
                    timer -= Time.deltaTime;

                    if (timer <= 0f)
                    {
                        if (TryTakeEnemyAIAction(SetStateTakingTurn))
                        {
                            state = State.Busy;
                        }
                        else
                        {
                            TurnSystem.Instance.NextUnitOnCurrentTurn();
                        }

                    }

                    break;
                case State.Busy:
                    break;
            }

        }

        private void SetStateTakingTurn()
        {
            timer = .5f;
            state = State.TakingTurn;
        }

        private void TurnSystem_OnUnitTurnChanged(object sender, EventArgs e)
        {
            if (!TurnSystem.Instance.IsCurrentPlayerTurn())
            {
                alreadyUseAction = false;
                state = State.TakingTurn;
                timer = 2f;
            }
        }

        private bool TryTakeEnemyAIAction(Action onEnemyAIActionComplete)
        {
            Unit enemyUnit = TurnSystem.Instance.GetCurrentUnit();
            if (TryTakeEnemyAIAction(enemyUnit, onEnemyAIActionComplete))
                return true;


            return false;
        }


        private bool TryTakeEnemyAIAction(Unit enemyUnit, Action onEnemyAIActionComplete)
        {
            EnemyAIAction bestEnemyAIAction = null;
            BaseAction bestBaseAction = null;

            foreach (BaseAction baseAction in enemyUnit.GetBaseActionArray())
            {

                if (!enemyUnit.CanSpendSkillToTakeSkillAction(baseAction))
                {
                    //enemy gk bisa lakuin ini
                    continue;
                }
                Debug.Log("Bisa Kepake:" + baseAction);
                if (bestEnemyAIAction == null)
                {
                    bestEnemyAIAction = baseAction.GetEnemyAIAction();
                    bestBaseAction = baseAction;
                }
                else
                {
                    EnemyAIAction testEnemyAIAction = baseAction.GetEnemyAIAction();
                    if (testEnemyAIAction != null && testEnemyAIAction.actionValue > bestEnemyAIAction.actionValue)
                    {
                        bestEnemyAIAction = testEnemyAIAction;
                        bestBaseAction = baseAction;
                    }
                }
                baseAction.GetBestEnemyAIAction();
            }

            if (bestEnemyAIAction != null && enemyUnit.TrySpendActionPointsToTakeAction(bestBaseAction) && !alreadyUseAction)
            {
                bestBaseAction.TakeAction(onEnemyAIActionComplete);
                alreadyUseAction = true;
                return true;
            }
            else
            {
                return false;
            }

        }

        private void GameManager_OnCombatStateChanged(object sender, GameManager.CombatState e)
        {
            if(e == GameManager.CombatState.Over)
            {
                this.enabled = false;
            }
            else if(e == GameManager.CombatState.Battle)
            {
                this.enabled = true;
            }
        }

    }

}
