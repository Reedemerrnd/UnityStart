using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class PlayerHealth : Health , IHealing
{
    [SerializeField]
    private bool _GodMode = false;
    public bool CanHeal()
    {
        if (_health < _maxHealth) return true;
        else return false;
    }
    public void Heal(float amount)
    {
        _health += amount;
        if (_health > _maxHealth) _health = _maxHealth;
        Debug.Log(_health);
    }
    public override void Hit(float damage)
    {
        if (_GodMode) return;
        _health -= damage;
        Debug.Log(_health);
        if (_health <= 0) Die();
    }
    private void Die()
    {
        gameObject.SetActive(false);
    }
}
