using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour,IWeapon
{
    private ParticleSystem shot;
    [SerializeField]
    private float _damage;
    [SerializeField]
    private float _fireRate;
    private float _timer;

    GameObject shooter;

    public GameObject Shooter => shooter;

    private void Start()
    {
        shot = GetComponent<ParticleSystem>();
        shooter = transform.parent.gameObject;

    }
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("part coll");
        Debug.Log(other.tag);
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<AIHealth>().Hit(_damage, Shooter);
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
}
