using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    /* При каждом варианте загрузка процессора выросла до 20% от простоя, 
     * загрузка гп выросла до 40%, использование оперативной памяти и памяти гп не изменилось
     */
	public GameObject objRot;
    public GameObject objEmpt;
    public List<GameObject> emtList;
    public bool SwitchMode = true;
    private void Start()
    {
        if (SwitchMode)
        {
            for (int i = 0; i < 10000; i++)
            {
                Instantiate(objRot, transform);
            }
        }
        else
        {
            for (int i = 0; i < 10000; i++)
            {
                emtList.Add(Instantiate(objEmpt, transform));
            }
        }
    }
    private void Update()
    {
        if (!SwitchMode)
        {
            foreach (GameObject obj in emtList)
            {
                obj.transform.Rotate(0, 10, 0);
            }
        }
    }
}
