using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    private GameObject _winImage;
    private void Awake()
    {
        _winImage = transform.Find("WinImage").gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("Level Completed");
            other.gameObject.SetActive(false);
            _winImage.SetActive(true);
        }
    }
}
