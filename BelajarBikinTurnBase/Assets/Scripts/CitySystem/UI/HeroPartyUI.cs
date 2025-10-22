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

    private HeroDataSO heroData;

    public void SetUp(HeroDataSO heroData)
    {
        this.heroData = heroData;

        unitImage.sprite = heroData.GetHeroSprite();

        heroData.OnHealthChanged += HeroData_OnHealthChanged;
        heroData.OnManaChanged += HeroData_OnManaChanged;

        PauseUI.instance.OnStateChanged += PauseUI_OnStateChanged;

        button.onClick.AddListener(() =>
        {
            InventoryManager.instance.GetSelectedItemBase().UseItem(heroData);
            PauseUI.instance.SetState(PauseUI.State.SelectItemMenu);

        });

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

    private void HeroData_OnManaChanged(object sender, int e)
    {
        Refresh();
    }

    private void HeroData_OnHealthChanged(object sender, int e)
    {
        Refresh();
    }

    public void Refresh()
    {
        healthText.text = heroData.GetHealth().ToString();
        healthBarImage.fillAmount = heroData.GetHealthNormalized();

        manaText.text = heroData.GetMana().ToString();
        manaBarImage.fillAmount = heroData.GetManaNormalized();

    }

    public Button GetButton()
    {
        return button;
    }

    private void OnDestroy()
    {
        PauseUI.instance.OnStateChanged -= PauseUI_OnStateChanged;

        if (heroData == null)
            return;
        heroData.OnHealthChanged -= HeroData_OnHealthChanged;
        heroData.OnManaChanged -= HeroData_OnManaChanged;
    }

}
