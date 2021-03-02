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

    private void Start()
    {
        _layermask = ~(LayerMask.NameToLayer("Enemy") | LayerMask.NameToLayer("Player"));
        _isActivated = false;
        _time = Time.time;
        _trigger = GetComponent<SphereCollider>();
        _trigger.enabled = false;
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            _targets = Physics.OverlapSphere(transform.position, 5.0f, _layermask);
            //var _finTargets = _targets.ToList().Distinct();
            Boom(_targets);
            Destroy(gameObject);
        }
    }
    private void Boom(IEnumerable<Collider> targ)
    {
        foreach (Collider coll in targ)
        {
            // вызвать  Hit  только на одном объекте
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
