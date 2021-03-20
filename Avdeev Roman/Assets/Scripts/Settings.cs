using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private Button _resumeButt;
    [SerializeField]
    private Button _backToMainButt;
    [SerializeField]
    private Toggle _muteToggle;
    [SerializeField]
    private Slider _sensivitySlider;
    [SerializeField]
    private Slider _volumeSlider;
    //для меню настроек
    [SerializeField]
    private GameObject _settingsMenu;
    private bool _settingsOpen = false;
    private void Awake()
    {
        Cursor.visible = true;
        _resumeButt.onClick.AddListener(Close);
        _backToMainButt.onClick.AddListener(ExitApp);
        _muteToggle.onValueChanged.AddListener(MuteSound);
        _sensivitySlider.onValueChanged.AddListener(SensivityChange);
        _volumeSlider.onValueChanged.AddListener(VolumeChange);
        _settingsMenu.SetActive(false);
    }
    private void Update()
    {
        //открыть настройки
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("esc");
            if (!_settingsOpen)
            {
                Open();
            }
            else
            {
                Close();
            }
        }
    }
    private void Close()
    {
        Debug.Log("close settings");
        SettingsManager.instance.ResumeGame();
        _settingsOpen = false;
        _settingsMenu.SetActive(false);
    }
    private void Open()
    {
        Debug.Log("open settings");
        _settingsMenu.SetActive(true);
        _settingsOpen = true;
        SettingsManager.instance.PauseGame();
    }
    private void MuteSound(bool value)
    {
        AudioManager.instance.Mute(value);
    }
    private void VolumeChange(float value)
    {
        AudioManager.instance.VoumeChange(value);
    }
    private void SensivityChange(float value)
    {
        SettingsManager.instance.SetSensivity(value, value);
    }
    private void ExitApp()
    {
        Debug.Log("Exit app");
        Application.Quit();
    }
}
