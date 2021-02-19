using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riddle : MonoBehaviour
{
    LeverRiddle _lever_1;
    LeverRiddle _lever_2;
    LeverRiddle _lever_3;
    bool _stage1 = false;
    bool _stage2 = false;
    bool _stage3 = false;
    Transform _bonusDoor;
    Transform _mainDoor;

    // Start is called before the first frame update
    void Start()
    {

        _lever_1 = transform.Find("Lever_1").GetComponent<LeverRiddle>();
        _lever_2 = transform.Find("Lever_2").GetComponent<LeverRiddle>(); 
        _lever_3 = transform.Find("Lever_3").GetComponent<LeverRiddle>(); 
        _bonusDoor = transform.Find("Bonus");
        _mainDoor = transform.Find("Main");
        DeactivateAll();
    }
    public void CheckLevers()
    {
        if (!_stage1 &&_lever_1.Avtivated)
        {
            _stage1 = true;
            Debug.Log("stage1");
        }
        else if(_stage1 && _lever_3.Avtivated && !_stage2)
        {
            _stage2 = true;

            Debug.Log("stage2");
        }
        else if(_stage2 && _lever_2.Avtivated && !_stage3)
        {
            _mainDoor.GetComponent<OpenDoor>().Activate();

            _stage3 = true;
            Debug.Log("stage3");
        } 
        else if (_stage3 && _lever_3.Avtivated)
        {
            _bonusDoor.GetComponent<OpenDoor>().Activate();
            Debug.Log("Bonus");
        }
        else 
        {
            Debug.Log("Wrong");
            _stage1 = false;
            _stage2 = false;
            _stage3 = false;
        }
        DeactivateAll();



    }
    private void DeactivateAll()
    {
        _lever_1.Deactivate();
        _lever_2.Deactivate();
        _lever_3.Deactivate();
    }
}
