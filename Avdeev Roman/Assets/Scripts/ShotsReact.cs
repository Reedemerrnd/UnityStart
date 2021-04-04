using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotsReact : MonoBehaviour
{
    public ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("hit");
        Instantiate(particle, other.transform.position, other.transform.rotation);
    }
}
