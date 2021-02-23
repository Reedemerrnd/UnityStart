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

    public ParticleSystem particle;
    private GameObject shooter;
    public GameObject Shooter => shooter;

    void Start()
    {
        _cam = transform.parent.GetComponent<Camera>();
        shooter = transform.parent.gameObject;
    }
    public  void Fire()
    {
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            //_cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObj = hit.transform.gameObject;

            AIHealth target = hitObj.GetComponent<AIHealth>();
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
}