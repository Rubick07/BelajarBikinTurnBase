using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class PauseUI : MonoBehaviour
{
    public enum State
    {
        MainMenu,
        InventoryMenu,
        SelectItemMenu,
        Selecthero
    }

    public static PauseUI instance;

    public event EventHandler<State> OnStateChanged;

    public State state;

    [Header("BUTTON REFERENCE")]
    [SerializeField] private Button itemButton;
    [SerializeField] private Button equipmentButton;
    [SerializeField] private Button settingButton;

    [Header("GROUP TRANSFORM REFERENCE")]
    [SerializeField] private RectTransform pauseUITopGroupTransform;
    [SerializeField] private RectTransform pauseUIBottomGroupTransform;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        PauseSystem.instance.OnGamePause += PauseSystem_OnGamePause;
        PauseSystem.instance.OnGameUnPause += PauseSystem_OnGameUnPause;


        OnStateChanged += PauseUI_OnStateChanged;

        itemButton.onClick.AddListener(() => {
            SetState(State.InventoryMenu);
        });

        pauseUIBottomGroupTransform.DOAnchorPosY(-160, 0f);
        pauseUITopGroupTransform.DOAnchorPosY(230, 0f);
        //Hide();
    }


    private void PauseSystem_OnGameUnPause(object sender, System.EventArgs e)
    {
        pauseUIBottomGroupTransform.DOAnchorPosY(-160, 1f).OnComplete(() => {
            EventSystem.current.SetSelectedGameObject(null);
        });
        pauseUITopGroupTransform.DOAnchorPosY(230, 1f);
    }

    private void PauseSystem_OnGamePause(object sender, System.EventArgs e)
    {
        SetState(State.MainMenu);
        pauseUIBottomGroupTransform.DOAnchorPosY(0, 1f).OnComplete(() => {
            EventSystem.current.SetSelectedGameObject(itemButton.gameObject);
        });
        pauseUITopGroupTransform.DOAnchorPosY(0, 1f);
    }

    private void PauseUI_OnStateChanged(object sender, State e)
    {
        if(e == State.MainMenu)
        {
            EventSystem.current.SetSelectedGameObject(itemButton.gameObject);

            itemButton.interactable = true;
            equipmentButton.interactable = true;
            settingButton.interactable = true;
        }
        else
        {
            itemButton.interactable = false;
            equipmentButton.interactable = false;
            settingButton.interactable = false;
        }
    }

    public void SetState(State state)
    {
        this.state = state;

        OnStateChanged?.Invoke(this, state);
    }

    public State GetState()
    {
        return state;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        PauseSystem.instance.OnGamePause -= PauseSystem_OnGamePause;
        PauseSystem.instance.OnGameUnPause -= PauseSystem_OnGameUnPause;
    }

}
