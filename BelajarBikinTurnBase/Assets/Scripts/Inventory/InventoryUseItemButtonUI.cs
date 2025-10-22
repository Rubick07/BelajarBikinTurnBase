using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUseItemButtonUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemNameTextMeshPro;
    [SerializeField] private TextMeshProUGUI itemAmountsTextMeshPro;
    [SerializeField] private Image itemImage;
    [SerializeField] private Button button;

    private ItemBase itemBase;

    private void Start()
    {
        InventoryManager.instance.OnInventoryChanged += InventoryManager_OnInventoryChanged;

        PauseUI.instance.OnStateChanged += PauseUI_OnStateChanged;
    }

    private void PauseUI_OnStateChanged(object sender, PauseUI.State e)
    {
        if(e == PauseUI.State.SelectItemMenu)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }

    private void InventoryManager_OnInventoryChanged(object sender, System.EventArgs e)
    {
        itemAmountsTextMeshPro.text = InventoryManager.instance.GetItemAmounts(itemBase).ToString();
    }

    public void SetItemBaseButton(ItemBase itembase)
    {
        this.itemBase = itembase;
        itemImage.sprite = itemBase.GetItemSprite();
        itemNameTextMeshPro.text = itembase.name.ToUpper();
        itemAmountsTextMeshPro.text = InventoryManager.instance.GetItemAmounts(itembase).ToString();

        button.onClick.AddListener(() =>
        {
            InventoryManager.instance.SetSelectedItemBase(itembase);
            PauseUI.instance.SetState(PauseUI.State.Selecthero);
        });
    }

    public Button GetButton()
    {
        return button;
    }

    private void OnDestroy()
    {
        InventoryManager.instance.OnInventoryChanged -= InventoryManager_OnInventoryChanged;
    }
}
