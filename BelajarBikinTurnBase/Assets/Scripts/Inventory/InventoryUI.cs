using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

    [Header("BUTTON REFERENCE")]
    [SerializeField] private Button useButton;
    [SerializeField] private Button tossButton;

    [Header("Inventory Item REFERENCE")]
    [SerializeField] private Transform inventoryUseItemButtonPrefab;
    [SerializeField] private Transform inventoryItemButtonContainerTransform;

    private List<InventoryUseItemButtonUI> inventoryItemButtonList = new List<InventoryUseItemButtonUI>();

    private void Start()
    {
        PauseSystem.instance.OnGameUnPause += PauseSystem_OnGameUnPause;
        PauseSystem.instance.OnGamePause += PauseSystem_OnGamePause;
        PauseUI.instance.OnStateChanged += PauseUI_OnStateChanged;

        useButton.onClick.AddListener(() => {
            CreateInventoryItemButton();
            PauseUI.instance.SetState(PauseUI.State.SelectItemMenu);
        
        });

        Hide();
    }

    public void CreateInventoryItemButton()
    {
        RemoveButtonList();

        foreach (ItemBase itembase in InventoryManager.instance.GetInventoryDictionary().Keys)
        {
            Transform inventoryItemButtonTransform = Instantiate(inventoryUseItemButtonPrefab, inventoryItemButtonContainerTransform);
            InventoryUseItemButtonUI inventoryItemButtonUI =
                inventoryItemButtonTransform.GetComponent<InventoryUseItemButtonUI>();

            inventoryItemButtonUI.SetItemBaseButton(itembase);

            inventoryItemButtonList.Add(inventoryItemButtonUI);

        }

    }

    private void RemoveButtonList()
    {
        foreach (Transform buttonTransform in inventoryItemButtonContainerTransform)
        {
            Destroy(buttonTransform.gameObject);
        }

        inventoryItemButtonList.Clear();
    }

    private void PauseSystem_OnGamePause(object sender, System.EventArgs e)
    {
        RemoveButtonList();
    }
    private void PauseSystem_OnGameUnPause(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void PauseUI_OnStateChanged(object sender, PauseUI.State e)
    {
        if(e == PauseUI.State.MainMenu)
        {
            Hide();
        }
        else if(e == PauseUI.State.InventoryMenu)
        {
            Show();
            useButton.interactable = true;
            tossButton.interactable = true;
        }
        else if(e == PauseUI.State.SelectItemMenu)
        {
            EventSystem.current.SetSelectedGameObject(inventoryItemButtonList[0].GetButton().gameObject);
            useButton.interactable = false;
            tossButton.interactable = false;
        }
    }

    public void Show()
    {
        EventSystem.current.SetSelectedGameObject(useButton.gameObject);
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        PauseSystem.instance.OnGameUnPause -= PauseSystem_OnGameUnPause;
        PauseSystem.instance.OnGamePause -= PauseSystem_OnGamePause;
        PauseUI.instance.OnStateChanged -= PauseUI_OnStateChanged;
    }

}
