using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSpawner : MonoBehaviour
{
    [SerializeField] int _maxCOunt;
    public GameObject Zombie;
    int count;
    List<GameObject> stack = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
 
    }
    // Update is called once per frame
    private void Update()
    {
        if (stack.Count<_maxCOunt)
        {
           stack.Add(Instantiate(Zombie, gameObject.transform.position, gameObject.transform.rotation));

        }
        foreach (var enemy in stack)
        {
            if (enemy == null) stack.Remove(enemy);
        }
    }
}
