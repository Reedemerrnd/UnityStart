using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineLauncher : MonoBehaviour, IWeapon
{
    private Transform _shooter;
    [SerializeField]
    private float _baseDamage;
    private float _currDamage;
    [SerializeField]
    private GameObject _minePref;
    [SerializeField]
    private float _throwingForce = 2f;
    public Transform Shooter => _shooter;

    public void BuffDamage(bool buffed = false)
    {
        if (buffed)
        {
            _currDamage = _baseDamage * 2;
        }
        else _currDamage = _baseDamage;
    }

    public void Fire()
    {
        var mine = Instantiate(_minePref, transform.position, transform.rotation);
        mine.GetComponent<Mine>().SetDamage(_currDamage);
        mine.GetComponent<Rigidbody>().AddForce(transform.forward * _throwingForce, ForceMode.Impulse);

    }

}
