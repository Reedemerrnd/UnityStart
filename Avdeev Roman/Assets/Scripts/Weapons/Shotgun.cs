using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour,IWeapon
{
    private ParticleSystem shot;
    [SerializeField]
    private float _baseDamage;
    private float _currDamage;
    [SerializeField]
    private float _fireRate;
    private float _timer;

    Transform shooter;

    public Transform Shooter => shooter;

    private void Start()
    {
        shot = GetComponent<ParticleSystem>();
        shooter = transform.parent.transform;
        _currDamage = _baseDamage;

    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Health>().Hit(_currDamage, Shooter);
        }
    }

    public void Fire()
    {
        _timer = Time.time + _fireRate;
        if (_timer > Time.time)
        {
            shot.Play();
        }
    }

    public void BuffDamage(bool buffed = false)
    {
        if (buffed)
        {
            _currDamage = _baseDamage * 2;
        }
        else _currDamage = _baseDamage;
    }
}
