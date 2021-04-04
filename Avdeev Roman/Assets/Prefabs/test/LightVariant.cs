using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightVariant : MonoBehaviour
{

    [Header("Sun")]
    [SerializeField]
    private Color _sunSky, _sunEquator, _sunGround, _sunColor; // ÷вета солнца, и Ambient Skybox
    [Header("Moon")]
    [SerializeField]
    private Color _moonSky, _moonEquator, _moonGround, _moonColor; // ÷вета луны, и Ambient Skybox
    [SerializeField]
    private float RotateSpeed; // —корость вращени€ солнца
    [SerializeField]
    private Light Sun;
    private void Start()
    {
        Sun.color = _sunColor;
        RenderSettings.ambientSkyColor = _sunSky;
        RenderSettings.ambientGroundColor = _sunGround;
        RenderSettings.ambientEquatorColor = _sunEquator;
    }
    void Update()
    {
        var temp = Mathf.Abs((180 - transform.rotation.eulerAngles.y) / 180);   
        Sun.color = Color.Lerp(_sunColor, _moonColor, temp);
        RenderSettings.ambientSkyColor = Color.Lerp(_sunSky, _moonSky, temp);
        RenderSettings.ambientGroundColor = Color.Lerp(_sunGround, _moonGround, temp);
        RenderSettings.ambientEquatorColor = Color.Lerp(_sunEquator, _moonEquator, temp);

        transform.Rotate(transform.up, RotateSpeed, Space.Self);

    }
}
