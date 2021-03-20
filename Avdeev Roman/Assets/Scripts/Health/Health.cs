using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Health : MonoBehaviour
{
    [SerializeField] 
    protected float _maxHealth;
    [SerializeField]
    protected float _health;
    protected bool _isAlive;
    public UnityAction OnDeath;
    public bool IsAlive => _isAlive;
    protected virtual void Start()
    {
        _health = _maxHealth;
        _isAlive = true;
    }
    public virtual void Hit(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            _isAlive = false;
            OnDeath?.Invoke();
        }
    }
    public virtual void Hit(float damage, Transform hitter)
    {
        _health -= damage;
        if (_health <= 0)
        {
            _isAlive = false;
            OnDeath?.Invoke();
        }
    }
}
