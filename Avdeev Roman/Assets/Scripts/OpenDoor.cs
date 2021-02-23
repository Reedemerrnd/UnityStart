using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField]bool _isOpen = false;
    float currY;
    // Start is called before the first frame update
    void Start()
    {
        currY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isOpen && (currY - transform.position.y)<=10)
        {
            transform.Translate(Vector3.down * 10 * Time.deltaTime);
        }
    }
    public void Activate()
    {
        _isOpen = true;
    }
}
