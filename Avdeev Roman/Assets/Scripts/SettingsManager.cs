using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance;
    [SerializeField]
    private GameObject _player;
    private PlayerControls _playerControls;
    private bool _isPaused = false;
    public bool IsPaused => _isPaused;
    public bool Mute { get; set; }
    public int Volume { get; set; }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        _playerControls = _player.GetComponent<PlayerControls>();
    }
    public void SetSensivity(float X, float Y)
    {
        _playerControls.SensivityX = X;
        _playerControls.SensivityY = Y;
    }
    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        _playerControls.Enabled = false;
    }
    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        _playerControls.Enabled = true;
    }
}
