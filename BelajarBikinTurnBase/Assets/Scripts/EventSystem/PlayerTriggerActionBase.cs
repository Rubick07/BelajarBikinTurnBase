using UnityEngine;

public abstract class PlayerTriggerActionBase : MonoBehaviour
{
    [SerializeField] protected bool autoAddToTrigger;
    [SerializeField] protected bool AddOnTriggerEnter;
    [SerializeField] protected bool AddOnTriggerExit;

    public bool GetAutoAddToTrigger()
    {
        return autoAddToTrigger;
    }

    public bool GetAddOnTriggerEnter()
    {
        return AddOnTriggerEnter;
    }

    public bool GetAddOnTriggerExit()
    {
        return AddOnTriggerExit;
    }

    public abstract void ActionEvent();

}
