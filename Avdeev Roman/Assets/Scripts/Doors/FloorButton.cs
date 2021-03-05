using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : InteractiveActivator
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy") || other.CompareTag("Key"))
            OnActivation?.Invoke();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy") || other.CompareTag("Key"))
            OnDeactivation?.Invoke();
    }
}
