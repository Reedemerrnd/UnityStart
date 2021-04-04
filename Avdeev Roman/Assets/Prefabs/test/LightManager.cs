using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [Header("Sun")]
    [SerializeField]
    private Color _sunSky, _sunEquator, _sunGround, _sunColor; // ����� ������, � Ambient Skybox
    [Header("Moon")]
    [SerializeField]
    private Color _moonSky, _moonEquator, _moonGround, _moonColor; // ����� ����, � Ambient Skybox
    [SerializeField]
    private float RotateSpeed; // �������� �������� ������
    [SerializeField]
    private Light Sun;
    [SerializeField]
    private Light Moon;// ������ �� �������� ���������
    private void Start()
    {
        Sun.color = _sunColor;
        Moon.color = _moonColor;
    }

    void Update()
    {
        if (transform.rotation.eulerAngles.x >= 0 && transform.rotation.eulerAngles.x < 200)
        {
            // ����������� Ambient Skybox Color
            Moon.gameObject.SetActive(false);
            Sun.gameObject.SetActive(true);
            RenderSettings.ambientSkyColor = _sunSky;
            RenderSettings.ambientGroundColor = _sunGround;
            RenderSettings.ambientEquatorColor = _sunEquator;
        }
        if (transform.rotation.eulerAngles.x >= 200 && transform.rotation.eulerAngles.x < 360)
        {
            Moon.gameObject.SetActive(true);
            Sun.gameObject.SetActive(false);
            RenderSettings.ambientSkyColor = _moonSky;
            RenderSettings.ambientGroundColor = _moonGround;
            RenderSettings.ambientEquatorColor = _moonEquator;
        }
        transform.Rotate(transform.right, RotateSpeed, Space.Self);

    }
}
