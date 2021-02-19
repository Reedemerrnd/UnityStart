using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    
    
    [SerializeField]Camera _cam;
    CharacterController body;
    public float sensivityHor = 9.0f;
    public float sensivityVer = 9.0f;
    
    public float minVert = -45.0f;
    public float maxVert = 45.0f;

    private float _rotationX = 0;

    private void Start()
    {
        body = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
       
            _rotationX -= Input.GetAxis("Mouse Y") * sensivityVer;
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);

            float delta = Input.GetAxis("Mouse X") * sensivityHor;
            float rotationY = body.transform.localEulerAngles.y + delta;
            body.transform.localEulerAngles = new Vector3(0, rotationY, 0);
            _cam.transform.localEulerAngles = new Vector3(_rotationX, 0, 0);
       
    }
}
