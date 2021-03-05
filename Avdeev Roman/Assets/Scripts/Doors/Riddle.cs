using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riddle : MonoBehaviour
{
    [SerializeField]
    private InteractiveActivator _lever_1;
    [SerializeField]
    private InteractiveActivator _lever_2;
    [SerializeField]
    private InteractiveActivator _lever_3;
    bool _stage1;
    bool _stage2;
    bool _stage3;
    [SerializeField]
    private GameObject _bonusDoor;
    [SerializeField]
    private GameObject _mainDoor;
    private void Start()
    {
        _lever_1.OnActivation += CheckLevers;
        _lever_2.OnActivation += CheckLevers;
        _lever_3.OnActivation += CheckLevers;

        _lever_3.OnDeactivation += CheckLevers;

        _stage1 = false;
        _stage2 = false;
        _stage3 = false;
    }
    public void CheckLevers()
{
        if (!_stage1 && _lever_1.IsActivated)
        {
            _stage1 = true;
            Debug.Log("stage1");
        }
        else if (_stage1 && _lever_3.IsActivated && !_stage2)
        {
            _stage2 = true;

            Debug.Log("stage2");
        }
        else if (_stage2 && _lever_2.IsActivated && !_stage3)
        {
            _mainDoor.GetComponent<OpenDoor>().Open();

            _stage3 = true;
            Debug.Log("stage3");
        }
        else if (_stage3 && !_lever_3.IsActivated)
        {
            _bonusDoor.GetComponent<OpenDoor>().Open();
            Debug.Log("Bonus");
        }
        else
        {
            Debug.Log("Wrong");
            DeactivateAll();
            _stage1 = false;
            _stage2 = false;
            _stage3 = false;
        }



    }
    private void DeactivateAll()
    {
        _lever_1.Deactivate();
        _lever_2.Deactivate();
        _lever_3.Deactivate();
    }

}
