using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField]
    private InteractiveActivator _lever;
    private Animator _anim;
    private void Start()
    {
        _anim = GetComponent<Animator>();
        if (_lever != null)
        {
            _lever.GetComponent<InteractiveActivator>().OnActivation += Open;
            _lever.GetComponent<InteractiveActivator>().OnDeactivation += Close;
        }
    }
    public void Open()
    {
        _anim.SetTrigger("Open");
    }
    public void Close()
    {
        Debug.Log("Closing");
        _anim.SetTrigger("Close");
    }
}
