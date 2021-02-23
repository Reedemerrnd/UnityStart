using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineLauncher : MonoBehaviour, IWeapon
{
    private Camera _cam;
    private GameObject shooter;
    [SerializeField]
    private GameObject mine;
    public GameObject Shooter => shooter;
    private void Start()
    {
        _cam = transform.parent.GetComponent<Camera>();

    }
    public void Fire()
    {
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.point.y<=0.1f)
            Instantiate(mine, hit.point, Quaternion.identity);
    }

}
