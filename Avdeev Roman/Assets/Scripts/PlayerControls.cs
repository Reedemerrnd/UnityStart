using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public bool Enabled { get; set; }
    // для ходьбы
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private float _jumpHeight = 0.5f;
    private Vector3 _inputs;
    private Rigidbody _body;
    private bool _canJump;
    // для обзора
    [SerializeField]
    private float _sensivityHor = 10.0f;
    [SerializeField]
    private float _sensivityVer = 10.0f;
    public float SensivityX { get => _sensivityHor; set => _sensivityHor = value; }
    public float SensivityY { get => _sensivityVer; set => _sensivityVer = value; }
    private Transform _camJoint;
    private Transform _weaponJoint;
    private float minVert = -90.0f;
    private float maxVert = 90.0f;
    private float _rotationX = 0;
    // для стрельбы
    private IArmory _armory;
    [SerializeField]
    private Texture _cross;
    void Start()
    {
        _body = GetComponent<Rigidbody>();
        _camJoint = transform.Find("CamJoint");
        _weaponJoint = transform.Find("JointWeap");
        _armory = GetComponent<IArmory>();
        Enabled = true;
    }
    void Update()
    {
        if (Enabled)
        {
            //считываение преобразование Input для ходьбы
            _inputs.x = (Input.GetAxis("Horizontal") * _speed);
            _inputs.z = (Input.GetAxis("Vertical") * _speed);
            _inputs = transform.TransformDirection(_inputs);
            _inputs = Vector3.ClampMagnitude(_inputs, _speed);

            //считываение преобразование Input для обзора мышкой
            _rotationX -= Input.GetAxis("Mouse Y") * _sensivityVer;
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);
            float delta = Input.GetAxis("Mouse X") * _sensivityHor;
            float rotationY = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(0, rotationY, 0);
            // обзор
            _camJoint.transform.localEulerAngles = new Vector3(_rotationX, 0, 0);
            _weaponJoint.transform.localEulerAngles = new Vector3(_rotationX, 0, 0);

            //прыжок
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
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _armory.ChangeWeapon();
            }
            if (Input.GetMouseButtonDown(0))
            {
                _armory.FireWeapon();
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                _canJump = false;
            }
            CheckGround();
        }
    }
    private void FixedUpdate()
    {
        if (Enabled)
        {
            //ходьба
            _inputs *= Time.fixedDeltaTime;
            _body.MovePosition(transform.position + _inputs);
        }
    }
    private void CheckGround()
    {
        if (transform.position.y <= 0.2f)
        {
            _canJump = true;
        }
    }
    private void OnGUI()
    {
        if (Enabled)
        {
            int size = 30;
            float x = Screen.width / 2 - size / 4;
            float y = Screen.height / 2 - size / 2;
            GUI.Label(new Rect(x, y, size, size), _cross);
        }
    }
}
