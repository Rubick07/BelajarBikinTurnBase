using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextAction : MonoBehaviour
{
    [SerializeField] Transform damageTextPrefab;
    private HealthSystem healthSystem;

    private void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
    }

    private void Start()
    {
        healthSystem.OnDamaged += HealthSystem_OnDamaged;
    }

    private void HealthSystem_OnDamaged(object sender, System.EventArgs e)
    {
        Transform damageTextTransform = Instantiate(damageTextPrefab, transform);

        Vector3 offset = new Vector3(0.352f, 0.319f, 1f);

        damageTextTransform.localPosition = offset;

        DamageText damageText = damageTextTransform.GetComponent<DamageText>();
        damageText.SetUp(healthSystem.GetLastDamageValue());

        Destroy(damageTextTransform.gameObject, 1f);
    }

}
