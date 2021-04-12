using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    private Rigidbody[] _rigidbodies;
    private Collider[] _colliders;
    private Animator _anim;


    void Start()
    {
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
        _colliders = GetComponentsInChildren<Collider>();
        _anim = GetComponent<Animator>();
        SetRagdoll(false);

    }
    public void SetRagdoll(bool active)
    {
        _rigidbodies[1].AddForce(Vector3.back, ForceMode.Impulse);
        foreach (Rigidbody rb  in _rigidbodies)
        {
            rb.isKinematic = !active;
        }
        foreach (Collider col  in _colliders)
        {
            col.enabled = active;
        }

        //основной коллайдер и рб
        _anim.enabled = !active;
        _rigidbodies[0].isKinematic = active;
        _colliders[0].enabled = !active;
    }

}
