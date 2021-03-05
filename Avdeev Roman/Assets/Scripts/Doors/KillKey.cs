using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillKey : InteractiveActivator
{
    [SerializeField]
    private Health _enemy;

    private new void Start()
    {
        base.Start();
        _enemy.OnDeath += TargetDied;
    }
    private void TargetDied()
    {
        OnActivation?.Invoke();
    }
}
