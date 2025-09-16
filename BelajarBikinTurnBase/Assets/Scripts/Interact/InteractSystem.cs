using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSystem : MonoBehaviour
{
    public static InteractSystem instance;
    [SerializeField] private LayerMask interactLayerMask;

    RaycastHit hit;

    private void Awake()
    {
        instance = this; 
    }

    

    public void InteractCheck()
    {
        Physics.Raycast(transform.position + new Vector3(0, 1f, 0), transform.forward, out hit, 5f, interactLayerMask);
        if (hit.collider != null)
        {
            IInteractable interactable = hit.collider.gameObject.GetComponent<IInteractable>();
            interactable.Interact();
        }
    }

}
