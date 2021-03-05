using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FPSInput : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private float _jumpHeight = 0.5f;
    private Vector3 _inputs;
    private Rigidbody _body;
    private bool _canJump;

    void Start()
    {
        _body = GetComponent<Rigidbody>();

    }

    void Update()
    {
        _inputs.x =( Input.GetAxis("Horizontal")*_speed);
        _inputs.z = (Input.GetAxis("Vertical")*_speed);
        
        _inputs = transform.TransformDirection(_inputs);
       // _inputs.y = _body.velocity.y;
        //_inputs.x += _body.velocity.x;
        //_inputs.z += _body.velocity.z;
        _inputs = Vector3.ClampMagnitude(_inputs, _speed);
        

        if (Input.GetKey(KeyCode.Space) && _canJump)
        {
            if (transform.position.y <= _jumpHeight)
            {
                _body.AddForce(Vector3.up * _jumpForce * (-Physics.gravity.y), ForceMode.Force);
                Debug.Log("try to jump");
            }
            else
            {
                _canJump = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _canJump = false;
        }
        CheckGround();

    }

    private void CheckGround()
    {
        if (transform.position.y <= 0.2f)
        {
            _canJump = true;
        }
    }

    private void FixedUpdate()
    {
        _inputs *= Time.fixedDeltaTime;
        //_body.velocity = _inputs;
        //_body.AddForce(_inputs * _speed *Time.fixedDeltaTime, ForceMode.VelocityChange);
        //transform.Translate(_inputs*Time.fixedDeltaTime);
        _body.MovePosition(transform.position + _inputs);
    }
}
