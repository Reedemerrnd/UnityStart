using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    [SerializeField] float _amount = 10.0f;
    PlayerHealth _playerHealth;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerHealth = other.GetComponent<PlayerHealth>();
            if (_playerHealth.CanHeal())
            {
                _playerHealth.Heal(_amount);
                Destroy(gameObject);
            }
        }
    }

}
