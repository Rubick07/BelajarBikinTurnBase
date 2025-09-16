using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyCollisionAction : MonoBehaviour
{
    public EventHandler OnCollisionWithPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ThirdPersonController>(out ThirdPersonController thirdPersonController))
        {
            Debug.Log("Test");
            OnCollisionWithPlayer?.Invoke(this, EventArgs.Empty);
        }
    }
}
