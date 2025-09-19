using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitUI : MonoBehaviour
{
    [SerializeField] private Image unitImage;
    [SerializeField] private Image healthBarImage;
    [SerializeField] private Image manaBarImage;
    [SerializeField] private TextMeshProUGUI descText;

    private HealthSystem healthSystem;
    private ManaSystem manaSystem;

    public void SetUp(Unit unit)
    {
        healthSystem = unit.GetHealthSystem();
        manaSystem = unit.GetManaSystem();
        unitImage.sprite = unit.GetUnitImage();

        healthSystem.OnDamaged += HealthSystem_OnDamaged;
        healthSystem.OnRestoreHealth += HealthSystem_OnRestoreHealth;

        manaSystem.OnConsumeMana += ManaSystem_OnConsumeMana;
        manaSystem.OnRestoreMana += ManaSystem_OnRestoreMana;

        Refresh();
    }

    private void ManaSystem_OnRestoreMana(object sender, System.EventArgs e)
    {
        Refresh();
    }

    private void HealthSystem_OnRestoreHealth(object sender, System.EventArgs e)
    {
        Refresh();
    }

    private void ManaSystem_OnConsumeMana(object sender, System.EventArgs e)
    {
        manaBarImage.fillAmount = manaSystem.GetManaNormalized();
        Refresh();
    }

    private void HealthSystem_OnDamaged(object sender, System.EventArgs e)
    {
        healthBarImage.fillAmount = healthSystem.GetHealthNormalized();
        Refresh();
    }

    public void Refresh()
    {
        descText.text = "HP     SP\n" + healthSystem.GetHealth() + "/" + manaSystem.GetMana();
    }

}
