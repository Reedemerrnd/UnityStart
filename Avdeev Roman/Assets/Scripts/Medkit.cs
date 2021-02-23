using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Medkit : MonoBehaviour
{
    [SerializeField] float _amount = 10.0f;
    IHealing _playerHealth;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerHealth = other.GetComponent<IHealing>();
            if (_playerHealth.CanHeal())
            {
                _playerHealth.Heal(_amount);
                Destroy(gameObject);
            }
        }
    }

}
