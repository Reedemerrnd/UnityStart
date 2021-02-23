using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    enum Mode
    {
        Ray,
        Mine
    }
    [SerializeField] Mode shootMode = Mode.Ray;
    private Camera _cam;
    public Texture cross;
    [SerializeField] float _damage = 3.0f;
    public float Damage { get => _damage; }
    public ParticleSystem particle;
    public GameObject mine;
    public ParticleSystem shots;
    // Start is called before the first frame update
    void Start()
    {
        _cam = transform.Find("MainCam").GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!shots.isPlaying)
            {
                shots.Play();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (shootMode == Mode.Ray)
                {
                    GameObject hitObj = hit.transform.gameObject;

                    AIHealth target = hitObj.GetComponent<AIHealth>();
                    if (target != null)
                    {
                        target.Hit(_damage, gameObject);

                    }
                    else
                    {
                        Instantiate(particle, hit.point, hit.transform.rotation);
                        Debug.Log(hitObj);
                    }
                }
                else if (shootMode == Mode.Mine)
                {
                    Instantiate(mine, hit.point, Quaternion.identity);
                }
            
        }
        }
    }
    public void DoubleDamage()
    {
        _damage *= 2;
    }
    private void OnGUI()
    {
        int size = 30;
        float x = _cam.pixelWidth / 2 - size / 4;
        float y = _cam.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(x, y, size, size),cross);
    }
}
