using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    
    
    [SerializeField]
    private Camera _cam;
    private Rigidbody _body;
    [SerializeField]
    private float _sensivityHor = 9.0f;
    [SerializeField]
    private float _sensivityVer = 9.0f;
    
    private float minVert = -90.0f;
    private float maxVert = 90.0f;

    private float _rotationX = 0;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
       
            _rotationX -= Input.GetAxis("Mouse Y") * _sensivityVer;
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);

            float delta = Input.GetAxis("Mouse X") * _sensivityHor;
            float rotationY = _body.transform.localEulerAngles.y + delta;
            _body.transform.localEulerAngles = new Vector3(0, rotationY, 0);
            _cam.transform.localEulerAngles = new Vector3(_rotationX, 0, 0);
       
    }
}
