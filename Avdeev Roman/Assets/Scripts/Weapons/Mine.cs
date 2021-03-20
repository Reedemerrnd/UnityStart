using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField]
    private float _damage = 10.0f;
    [SerializeField]
    private float _activationTime = 1.0f;
    [SerializeField]
    private float _expForce;
    private float _time;
    private Collider _trigger;
    private bool _isActivated;
    private Collider[] _targets;
    private int _layermask;
    private AudioSource _explosionSound;
    [SerializeField]
    private ParticleSystem _explosionParticle;

    private void Start()
    {
        _layermask = ~(LayerMask.NameToLayer("Enemy") | LayerMask.NameToLayer("Player"));
        _isActivated = false;
        _time = Time.time;
        _trigger = GetComponent<SphereCollider>();
        _trigger.enabled = false;
        _explosionSound = GetComponent<AudioSource>();

    }
    private void Update()
    {
        if ((Time.time >= _time + _activationTime) && !_isActivated)
        {
            _isActivated = true;
            Destroy(gameObject, 4);
            _trigger.enabled = true;
        }   
    }
    public void SetDamage(float damage)
    {
        _damage = damage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            _targets = Physics.OverlapSphere(transform.position, 5.0f, _layermask);
            Boom(_targets);
            _explosionSound.Play();
            _explosionParticle.Play();
            transform.Find("Body").gameObject.SetActive(false);
            _trigger.enabled = false;
            Destroy(gameObject,1);
        }
    }
    private void Boom(Collider[] targ)
    {
        foreach (Collider coll in targ)
        {
            if (coll.CompareTag("Enemy") || coll.CompareTag("Player"))
            {

                coll.GetComponent<Health>()?.Hit(_damage);
                coll.GetComponent<Rigidbody>()?.AddForce(
                    (coll.transform.position - transform.position).normalized * _expForce,
                    ForceMode.Impulse);
            }

        }
    }

}
