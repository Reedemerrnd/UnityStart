using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _damage = 2.0f;
        private void Start()
    {
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Health>().Hit(_damage);
            Destroy(gameObject);
        }
        else if(other.CompareTag("Level")) 
            Destroy(gameObject);
    }
}
