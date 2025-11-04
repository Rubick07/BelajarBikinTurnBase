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

    HeroDynamicData asdf;

    private void Start()
    {
        asdf = HeroPartyManager.instance.GetHeroDynamicDataList()[0];
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            GameManager.instance.SetCombatState(GameManager.CombatState.Battle);

        if (Input.GetKeyDown(KeyCode.I)){
            SceneManager.LoadScene("CombatSystemScene");
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            EconomyManager.instance.AddMoney(100);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            asdf.ModifyHealth(-20);
        }



    }
}
