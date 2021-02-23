using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    Transform _target;
    [SerializeField] GameObject _bulletPref;
    GameObject _bullet;
    bool _playerSpotted = false;
    [SerializeField] float _speed = 0.5f;
    Transform _muzzle;
    float _minAnlge;
    float _maxAngle;
    private void Start()
    {
        _muzzle = transform.Find("Muzzle");
        _minAnlge = transform.rotation.eulerAngles.y - 45.0f;
        _maxAngle = transform.rotation.eulerAngles.y + 45.0f;

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _target = other.transform;
            _playerSpotted = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerSpotted = false;
        }
    }
    void Update()
    {
        if (_playerSpotted)
        {
            if(_bullet == null)
            {
                _bullet = Instantiate(_bulletPref, _muzzle);
                _bullet.transform.Rotate(new Vector3(-90, 0, 0), Space.Self);
                Debug.Log(_bullet);
            }

                var dir = _target.position - transform.position;
                dir.y += 3;
                var newDir = Vector3.RotateTowards(transform.forward, dir, _speed * Time.deltaTime, 0f);
                var quat = Quaternion.LookRotation(newDir);
                transform.rotation = quat;

        }
    }
}
