using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FPSInput : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1f;
    [SerializeField]
    private float _jumpForce = 100f;
    private Vector3 _inputs;
    private Rigidbody _body;

    void Start()
    {

        _body = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        _inputs = Vector3.zero;
        _inputs.x = Input.GetAxis("Horizontal") * _speed;
        _inputs.z = Input.GetAxis("Vertical") * _speed;

        _inputs = Vector3.ClampMagnitude(_inputs, _speed);
        _inputs = transform.TransformDirection(_inputs);

        
        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y<=0.2f)
        {
            transform.GetComponent<Rigidbody>()
                .AddForce(
                Vector3.up * _jumpForce*(-Physics.gravity.y),
                ForceMode.Force
                );
            Debug.Log("try to jump");
        }
    }
    private void FixedUpdate()
    {
        _body.MovePosition(_body.position + _inputs *Time.fixedDeltaTime);
    }
}
