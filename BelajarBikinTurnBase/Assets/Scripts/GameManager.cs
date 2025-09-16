using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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


}
