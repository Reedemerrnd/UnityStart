using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private Light _flashLight;
    private bool _isActive = false;
    void Start()
    {
        _flashLight = GetComponent<Light>();
        _flashLight.enabled = _isActive;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _isActive = !_isActive;
            _flashLight.enabled = _isActive;
        }
    }
}
