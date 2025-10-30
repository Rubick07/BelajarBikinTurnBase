using UnityEngine;

public class ChangeSceneTrigger : PlayerTriggerActionBase
{
    [SerializeField] private Loader.Scene targetScene;

    public override void ActionEvent()
    {
        Loader.Load(targetScene);
    }
}
