using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour, IBuffed
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _currWeapon += 1;
            if (_currWeapon >= _weapons.Count) _currWeapon = 0;
        }

        if (Input.GetMouseButtonDown(0) && _weapons[_currWeapon] != null)
        {
            _weapons[_currWeapon].Fire();
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
    //private void OnGUI()
    //{
    //    int size = 30;
    //    float x = _cam.pixelWidth / 2 - size / 4;
    //    float y = _cam.pixelHeight / 2 - size / 2;
    //    GUI.Label(new Rect(x, y, size, size),cross);
    //}
}
