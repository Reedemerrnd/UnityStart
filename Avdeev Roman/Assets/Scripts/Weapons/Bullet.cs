using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _damage = 2.0f;
    [SerializeField] float _speed = 10.0f;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        Destroy(gameObject, 2);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Health>().Hit(_damage);
            Destroy(gameObject);
        }

    }
}
