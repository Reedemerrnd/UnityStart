using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampBlinking : MonoBehaviour
{
    [SerializeField]
    private bool _isBlinking = false;
    [SerializeField]
    private float _blinkMaxDelay=1;
    private Light _lamp;
    private float _timer;
    void Start()
    {
        _lamp = GetComponent<Light>();
        _timer = Time.time + Random.Range(0,_blinkMaxDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (_isBlinking)
        {
            Blink();
        }
    }
    private void Blink()
    {
        if (_timer <= Time.time)
        {
            _lamp.enabled = !_lamp.enabled;
            _timer = Time.time + Random.Range(0, _blinkMaxDelay);
        }
    }
    
}
