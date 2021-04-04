using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    
    [SerializeField] 
    private GameObject _bulletPref;     
    [SerializeField] 
    private float _speed = 0.5f;
    private GameObject _bullet;
    [SerializeField]
    private float _fireForce;
    bool _playerSpotted = false;
    Transform _target;
    Transform _bulletSpawn;
    private float _minAnlge;
    private float _maxAngle;
    private void Start()
    {
        _bulletSpawn = transform.Find("BulletSpawn");
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
            

                var dir = _target.position - transform.position;
                dir.y += 3;
                var newDir = Vector3.RotateTowards(transform.forward, dir, _speed * Time.deltaTime, 0f);
                var quat = Quaternion.LookRotation(newDir);
                transform.rotation = quat;
            if (_bullet == null)
            {
                _bullet = Instantiate(_bulletPref, _bulletSpawn);
                _bullet.GetComponent<Rigidbody>().AddForce(dir * _fireForce, ForceMode.Impulse);
                Debug.Log(_bullet);
            }

        }
    }
}
