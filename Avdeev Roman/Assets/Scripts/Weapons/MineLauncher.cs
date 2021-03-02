using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineLauncher : MonoBehaviour, IWeapon
{
    private Camera _cam;
    private Transform _shooter;
    [SerializeField]
    private GameObject _minePref;
    [SerializeField]
    private float _throwingForce = 2f;
    private Rigidbody _rigidbody;
    public Transform Shooter => _shooter;
    private void Start()
    {
        //_cam = transform.parent.GetComponent<Camera>();

    }
    public void Fire()
    {
        var mine = Instantiate(_minePref, transform.position, transform.rotation);
        mine.GetComponent<Rigidbody>().AddForce(transform.forward * _throwingForce, ForceMode.Impulse);
        //Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;
        //if (Physics.Raycast(ray, out hit) && hit.point.y<=0.1f)
        //    Instantiate(mine, hit.point, Quaternion.identity);
    }

}
