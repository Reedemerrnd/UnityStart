using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawEnemy : MonoBehaviour
{
    public GameObject Zombie;
    public Transform SpawnPos;
    // Start is called before the first frame update
    void Start()
    {
        var enemy = Instantiate(Zombie, SpawnPos.position, SpawnPos.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
