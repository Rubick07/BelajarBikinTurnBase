using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private HealthSystem healthSystem;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
            TurnSystem.Instance.NextUnitOnCurrentTurn();

        if (Input.GetKeyDown(KeyCode.I)){
            healthSystem.Damage(10);
        }

    }
}
