using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverRiddle : MonoBehaviour
{
    [SerializeField]bool _isActive = false;
    public bool Avtivated { get=> _isActive;}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        _isActive = true;
        transform.parent.GetComponent<Riddle>().CheckLevers();
    }
    public void Deactivate()
    {
        _isActive = false;
    }

}
