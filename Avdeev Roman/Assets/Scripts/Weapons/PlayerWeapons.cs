using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour, IBuffed, IArmory
{
    //private Camera _cam;
    //public Texture cross;
    private List<IWeapon> _weapons = new List<IWeapon>();
    private int _currWeapon = 0;
    private bool _buffed;
    private float _timer;
    private float _duration;

    void Start()
    {
        //_cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        transform.GetComponentsInChildren(_weapons);
        _buffed = false;

    }


    void Update()
    {
        //Руализация баффа подбираемого баффа с временем действия
        if (_buffed)
        {
            if (Time.time - _timer >= _duration)
            {
                _buffed = false;
                foreach (IWeapon weapon in _weapons)
                {
                    weapon.BuffDamage(false);
                }
                transform.Find("JointWeap").Find("Weapon").GetComponent<MeshRenderer>().material.color = Color.white;
            }
        }
        /*если while достаточно большой, 
        чтобы не успеть выполниться во время одного кадра
        (т.к. Update вызывается каждый кадр),
        while видимо фризит всё пока не выполнится 
        и не сможет начать выполняться следующий Update
        */
        //while (n <= 1000)
        //{
        //    if (Input.GetMouseButtonDown(0) && _weapons[_currWeapon] != null)
        //    {
        //        _weapons[_currWeapon].Fire();
        //    }
        //    n++;
        //}
    }
    public void ChangeWeapon()
        {
            _currWeapon += 1;
            if (_currWeapon >= _weapons.Count) _currWeapon = 0;
        }
    public void FireWeapon()
    {
        if (_weapons[_currWeapon] != null)
        {
            _weapons[_currWeapon].Fire();
        }
    }
    public void Buff(float duration)
    {
        _timer = Time.time;
        _duration = duration;
        _buffed = true;
        foreach (IWeapon weapon in _weapons)
        {
            weapon.BuffDamage(true);
        }
        transform.Find("JointWeap").Find("Weapon").GetComponent<MeshRenderer>().material.color = Color.red;
    }

}
