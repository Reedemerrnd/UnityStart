using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpotting : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        AIWander parent = transform.parent.GetComponent<AIWander>();
        if (other.tag == "Player")
        {
            parent.TargetSpotted(other.transform);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        AIWander parent = transform.parent.GetComponent<AIWander>();
        if (other.tag == "Player")
        {
            parent.TargetSpotted(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        AIWander parent = transform.parent.GetComponent<AIWander>();
        if (other.tag == "Player")
        {
            parent.TargetLastPos(other.transform);
        }
    }
}
