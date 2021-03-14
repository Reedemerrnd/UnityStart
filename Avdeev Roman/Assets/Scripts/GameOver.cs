using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private GameObject _lostImage;
    private void Awake()
    {
        _lostImage = transform.Find("LostImage").gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("Lost");
            other.gameObject.SetActive(false);
            _lostImage.SetActive(true);
        }
    }
}
