using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawEnemy : MonoBehaviour
{
    [SerializeField]
    private bool _spawnPatrol;
    [SerializeField]
    private List<Transform> _waypoints;

    [SerializeField]
    private GameObject Zombie;
    [SerializeField]
    private Transform SpawnPos;
    private GameObject _enemy;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }
    public void Spawn()
    {
        if (_enemy == null)
        {
            _enemy = Instantiate(Zombie, SpawnPos.position, SpawnPos.rotation);
            if (_spawnPatrol && _waypoints.Count>0)
            {
                _enemy.GetComponent<AIWander>().SetOnPAtrol(_waypoints);
            }
        }
    }
}
