using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class EyeFocus : MonoBehaviour
{
    private PostProcessVolume _profile;
    private DepthOfField _depthOfField;
    [SerializeField]
    private Camera _cam;
    [SerializeField]
    private float _camOffset = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        _profile = GetComponent<PostProcessVolume>();
        _profile.profile.TryGetSettings<DepthOfField>(out _depthOfField);
        _depthOfField.enabled.value = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit  hit;
        if(Physics.Raycast(ray,out hit))
        {
            if (hit.collider.CompareTag("PickableObject"))
            {
                _depthOfField.enabled.value = true;
                float dist = Vector3.Distance(_cam.transform.position, hit.point) + _camOffset;
                Debug.Log(dist);
                _depthOfField.focusDistance.value = dist;

            }
            else _depthOfField.enabled.value = false;
        }
            

        
    }
}
