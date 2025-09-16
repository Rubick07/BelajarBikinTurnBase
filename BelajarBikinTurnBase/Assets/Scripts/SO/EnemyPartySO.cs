using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "EnemyPartySO", menuName = "Scriptable Objects/EnemyPartySO")]
public class EnemyPartySO : ScriptableObject
{
    public List<GameObject> EnemyGameobjectList;
}
