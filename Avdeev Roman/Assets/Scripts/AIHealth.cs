using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : MonoBehaviour
{
    [SerializeField]
    float _health;
    AIWander wander;

    // Start is called before the first frame update
    void Start()
    {
        wander = GetComponent<AIWander>();
    }
    public void Hit(float damage, GameObject hitter)
    {
        wander.TargetSpotted(hitter);
        _health -= damage;
        if (_health <= 0)
        {
            wander.Die();
        }
    }
    public void Hit(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            wander.Die();
        }
    }
}
