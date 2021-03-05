using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class InteractiveActivator : MonoBehaviour
{
    public UnityAction OnActivation;
    public UnityAction OnDeactivation;
    protected bool _isActivated;
    public bool IsActivated => _isActivated;
    protected void Start()
    {
        _isActivated = false;
    }
    public void Deactivate()
    {
        _isActivated = false;
    }
}
