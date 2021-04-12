using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpotting : MonoBehaviour
{
    [SerializeField]
    private float _spotRadius = 10f;
    private AIWander _AIWander;
    private void Start()
    {
        _AIWander = GetComponent<AIWander>();
    }
    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _spotRadius);
        if (colliders.Length > 0)
        {
            var target = Array.Find(colliders, c => c.CompareTag("Player"));
            if (target != null)
            {
                _AIWander.TargetSpotted(target.transform);
            }
        }
    }
}
