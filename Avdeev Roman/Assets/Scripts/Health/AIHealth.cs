using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : Health
{
    private AIWander _wander;
    private new void Start()
    {
        base.Start();
        _wander = GetComponent<AIWander>();
    }
    public override void Hit(float damage, Transform hitter)
    {
        _wander.TargetLastPos(hitter);
        _health -= damage;
        if (_health <= 0)
        {
            _isAlive = false;
            OnDeath?.Invoke();
        }
    }

}
