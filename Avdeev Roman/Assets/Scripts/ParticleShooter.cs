using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleShooter : MonoBehaviour
{
    [SerializeField] float _damage = 2.0f;
    public float Damage { get => _damage;}
    public ParticleSystem shots;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {

        
        
    }


}
