using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCam : MonoBehaviour
{
    private Camera _cam;
    [SerializeField]
    bool _followPlayer;
    private Transform _player;
    void Start()
    {
        _cam = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (_followPlayer)
            _player = GameObject.FindGameObjectWithTag("Player").transform.Find("CamJoint");

    }

    // Update is called once per frame
    void Update()
    {
        if (_followPlayer)
        {
            transform.position = _player.position;
            transform.rotation = _player.rotation;
        }
    }

}
