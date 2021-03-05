using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : InteractiveActivator
{

 
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _isActivated = !_isActivated;
                if (_isActivated)
                {
                    OnActivation?.Invoke();
                }
                else
                {
                    OnDeactivation?.Invoke();
                }
            }
        }
    }
}
