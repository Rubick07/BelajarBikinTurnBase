using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    [SerializeField] private TextMeshPro meshPro;

    private void Update()
    {
        transform.position += Vector3.up * Time.deltaTime;
    }

    public void SetUp(int damageValue)
    {
        meshPro.text = damageValue.ToString();
    }


}
