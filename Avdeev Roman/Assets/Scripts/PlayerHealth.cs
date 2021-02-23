using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float _maxHealth = 20.0f;
    float _health;
    private void Start()
    {
        _health = _maxHealth;

    }
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
    public void Hit(float damage)
    {
        _health -= damage;
        Debug.Log(_health);
        if (_health <= 0) Die();
    }
    private void Die()
    {
        gameObject.SetActive(false);
    }
}
