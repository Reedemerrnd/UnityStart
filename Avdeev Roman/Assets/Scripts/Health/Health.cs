using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] 
    protected float _maxHealth;
    [SerializeField]
    protected float _health;
    protected bool _isAlive;
    public bool IsAlive => _isAlive;
    public virtual void Start()
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
        }
    }
    public virtual void Hit(float damage, Transform hitter)
    {
        _health -= damage;
        if (_health <= 0)
        {
            _isAlive = false;
        }
    }
}
