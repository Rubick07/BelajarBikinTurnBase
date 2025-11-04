using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroPartyUI : MonoBehaviour
{
    [SerializeField] private Image unitImage;
    [SerializeField] private Image healthBarImage;
    [SerializeField] private Image manaBarImage;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI manaText;
    [SerializeField] private Button button;

    private HeroDynamicData heroData;

    public void SetUp(HeroDynamicData heroData)
    {
        this.heroData = heroData;

        unitImage.sprite = heroData.GetHeroDataSO().GetHeroSprite();

        HeroDynamicData.OnAnyHealthChanged += HeroDynamicData_OnHealthChanged;
        HeroDynamicData.OnAnyManaChanged += HeroDynamicData_OnManaChanged;

        PauseUI.instance.OnStateChanged += PauseUI_OnStateChanged;

        button.onClick.AddListener(() =>
        {
            InventoryManager.instance.GetSelectedItemBase().UseItem(heroData);
            PauseUI.instance.SetState(PauseUI.State.SelectItemMenu);

        });

        Refresh();
    }

    private void HeroDynamicData_OnManaChanged(object sender, int e)
    {
        Refresh();
    }

    private void HeroDynamicData_OnHealthChanged(object sender, int e)
    {
        Refresh();
    }

    private void PauseUI_OnStateChanged(object sender, PauseUI.State e)
    {
        if (e == PauseUI.State.Selecthero)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }

    public void Refresh()
    {
        healthText.text = heroData.health.ToString();
        healthBarImage.fillAmount = heroData.GetHealthNormalized();

        manaText.text = heroData.mana.ToString();
        manaBarImage.fillAmount = heroData.GetManaNormalized();

    }

    public Button GetButton()
    {
        return button;
    }

    private void OnDestroy()
    {
        PauseUI.instance.OnStateChanged -= PauseUI_OnStateChanged;

        HeroDynamicData.OnAnyHealthChanged -= HeroDynamicData_OnHealthChanged;
        HeroDynamicData.OnAnyManaChanged -= HeroDynamicData_OnManaChanged;

        if (heroData == null)
            return;
    }

}
