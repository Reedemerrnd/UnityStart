using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    
   
    [SerializeField]
    private float _sensivityHor = 10.0f;
    [SerializeField]
    private float _sensivityVer = 10.0f;
    public float SensivityX { get=>_sensivityHor; set=>_sensivityHor = value; }
    public float SensivityY { get => _sensivityVer; set => _sensivityVer = value; }
    private Transform _camJoint;
    private Transform _weaponJoint;
    private float minVert = -90.0f;
    private float maxVert = 90.0f;

    private float _rotationX = 0;

    private void Start()
    {
        _camJoint = transform.Find("CamJoint");
        _weaponJoint = transform.Find("JointWeap");
    }

    // Update is called once per frame
    void Update()
    {
       
            _rotationX -= Input.GetAxis("Mouse Y") * _sensivityVer;
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);

            float delta = Input.GetAxis("Mouse X") * _sensivityHor;
            float rotationY = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(0, rotationY, 0);
            _camJoint.transform.localEulerAngles = new Vector3(_rotationX, 0, 0);
            _weaponJoint.transform.localEulerAngles = new Vector3(_rotationX, 0, 0);
        //_cam.transform.localEulerAngles = new Vector3(_rotationX, 0, 0);

    }

}
