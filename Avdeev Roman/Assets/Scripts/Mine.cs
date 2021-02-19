using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] float _damage = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var colliders = Physics.OverlapSphere(transform.position, 5.0f);
            foreach (var coll in colliders)
            {
                if (coll.CompareTag("Enemy"))
                {
                    coll.GetComponent<AIHealth>().Hit(_damage);
                }
            }
            Destroy(gameObject);
        }
        
    }
}
