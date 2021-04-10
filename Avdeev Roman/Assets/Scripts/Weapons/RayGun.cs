using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGun : MonoBehaviour, IWeapon
{
    [SerializeField]
    private float _damage;
    [SerializeField]
    private float _fireRate;
    private Camera _cam;
    private Transform _camJoint;
    [SerializeField]
    private Texture _cross;

    //public ParticleSystem particle;
    private Transform shooter;
    public Transform Shooter => shooter;

    void Start()
    {
        _cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    public  void Fire()
    {
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(transform.position, hit.point, Color.red,1.0f);
            GameObject hitObj = hit.transform.gameObject;
                Debug.Log(hit);
            Health target = hitObj.GetComponent<Health>();
            if (target != null)
            {
                target.Hit(_damage, transform);

            }

        }


    }
    private void OnGUI()
    {
            int size = 30;
            float x = Screen.width / 2 - size / 4;
            float y = Screen.height / 2 - size / 2;
            GUI.Label(new Rect(x, y, size, size), _cross);
    }

    public void BuffDamage(bool buffed)
    {
        throw new System.NotImplementedException();
    }
}