using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour,IWeapon
{
    private ParticleSystem _shotParticle;
    [SerializeField]
    private float _baseDamage;
    private float _currDamage;
    [SerializeField]
    private float _fireRate;
    private float _timer;
    private AudioSource _shotSound; 

    Transform shooter;

    public Transform Shooter => shooter;

    private void Start()
    {
        _shotParticle = GetComponent<ParticleSystem>();
        _shotSound = GetComponent<AudioSource>();
        shooter = transform.parent.transform;
        _currDamage = _baseDamage;
        _timer = 0;

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
        if (_timer <= Time.time)
        {
            _shotParticle.Play();
            _timer = Time.time + _fireRate;
            _shotSound.Play();
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
