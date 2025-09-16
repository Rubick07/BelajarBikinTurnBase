using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Testing : MonoBehaviour
{
    [SerializeField] private HealthSystem healthSystem;
    [SerializeField] private GameObject UITest;
    [SerializeField] private ItemBase itemBase;
    [SerializeField] private ItemBase itemBase2;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
            TurnSystem.Instance.NextUnitOnCurrentTurn();

        if (Input.GetKeyDown(KeyCode.I)){
            SceneManager.LoadScene("CombatSystemScene");
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            EconomyManager.instance.AddMoney(100);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            UITest.transform.DOMoveY(0, 1f);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            UITest.transform.DOMoveY(-120, 1f);
        }


    }
}
