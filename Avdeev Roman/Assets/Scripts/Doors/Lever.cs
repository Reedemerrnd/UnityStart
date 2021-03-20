using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : InteractiveActivator
{
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _isActivated = !_isActivated;
                if (_isActivated)
                {
                    _animator.SetTrigger("On");
                    OnActivation?.Invoke();
                }
                else
                {
                    _animator.SetTrigger("Off");
                    OnDeactivation?.Invoke();
                }
            }
        }
    }
    public override void Deactivate()
    {
        if (_isActivated)
        {
            _isActivated = false;
            _animator.SetTrigger("Off");
            OnDeactivation?.Invoke();
        }

    }
}
