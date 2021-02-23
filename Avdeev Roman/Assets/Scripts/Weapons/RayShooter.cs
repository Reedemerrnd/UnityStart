using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _cam;
    public Texture cross;
    private List<IWeapon> _weapons = new List<IWeapon>();
    private int _currWeapon = 0;

    // Start is called before the first frame update
    void Start()
    {
        _cam = transform.Find("MainCam").GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        transform.GetComponentsInChildren(_weapons);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            _currWeapon += 1;
            if (_currWeapon >= _weapons.Count) _currWeapon = 0;
        }
        
        if (Input.GetMouseButtonDown(0) && _weapons[_currWeapon]!=null)
        {
            _weapons[_currWeapon].Fire();
        }
    }
    public void DoubleDamage()
    {
        //_damage *= 2;
    }
    private void OnGUI()
    {
        int size = 30;
        float x = _cam.pixelWidth / 2 - size / 4;
        float y = _cam.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(x, y, size, size),cross);
    }
}
