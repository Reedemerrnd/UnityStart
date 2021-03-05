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

    public ParticleSystem particle;
    private Transform shooter;
    public Transform Shooter => shooter;

    void Start()
    {
        //_cam = transform.parent.GetComponent<Camera>();
        _camJoint = transform.parent.Find("CamJoint");
        shooter = transform.parent.transform;
    }
    public  void Fire()
    {
        //Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        //if (Physics.Raycast(ray, out hit))
        if (Physics.Raycast(_camJoint.position, Vector3.forward, out hit))
        {
            GameObject hitObj = hit.transform.gameObject;

            Health target = hitObj.GetComponent<Health>();
            if (target != null)
            {
                target.Hit(_damage, Shooter);

            }
            else
            {
                Instantiate(particle, hit.point, hit.transform.rotation);
            }

        }


    }

    public void BuffDamage(bool buffed)
    {
        throw new System.NotImplementedException();
    }
}