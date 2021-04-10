using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSController : MonoBehaviour
{
    private Animator _animator;

    [SerializeField]
    private Transform _camJoint;
    [SerializeField]
    private float _sensivityHor = 10.0f;
    [SerializeField]
    private float _sensivityVer = 10.0f;
    private float minVert = -90.0f;
    private float maxVert = 90.0f;
    private float _rotationX = 0;
    private float _rotationY = 0;


    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {

        //обзор мышью
        _rotationX -= Input.GetAxis("Mouse Y") * _sensivityVer;
        _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);
        float deltaY = Input.GetAxis("Mouse X") * _sensivityHor;
        float rotationY = transform.localEulerAngles.y + deltaY;
        _rotationY+= Input.GetAxis("Mouse X") * _sensivityHor;
        transform.localEulerAngles = new Vector3(0, rotationY, 0);
        _camJoint.transform.localEulerAngles = new Vector3(_rotationX, 0, 0);
    }
    private void FixedUpdate()
    {
        
        //движение аниматора
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        _animator.SetFloat("Vertical", v);
        _animator.SetFloat("Horizontal", h);
    }
    private void OnAnimatorIK(int layerIndex)
    {
        Quaternion q = Quaternion.Euler(0, 45, 0);
        _animator.SetBoneLocalRotation(HumanBodyBones.Spine, q);
    }
}
