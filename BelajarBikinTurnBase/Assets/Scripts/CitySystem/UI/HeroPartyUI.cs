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

    private HeroDataSO heroData;

    public void SetUp(HeroDataSO heroData)
    {
        this.heroData = heroData;

        unitImage.sprite = heroData.GetHeroSprite();

        heroData.OnHealthChanged += HeroData_OnHealthChanged;
        heroData.OnManaChanged += HeroData_OnManaChanged;


        Refresh();
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

}
