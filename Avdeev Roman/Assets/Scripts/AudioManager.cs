using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField]
    private AudioMixer _audioMixer;
    private float _lastVolume;
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
        _audioMixer.GetFloat("MasterVolume", out _lastVolume);
    }
    public void VoumeChange(float value)
    {
        float volume = value - 80f;
        if (volume > 20) volume = 20f;
        else if (volume < -80) volume = -80f;
        _audioMixer.SetFloat("MasterVolume", volume);
    }
    public void Mute(bool muted)
    {
        if (muted)
        {
            _audioMixer.GetFloat("MasterVolume", out _lastVolume);
            _audioMixer.SetFloat("MasterVolume", -80f);
        }
        else
        {
            _audioMixer.SetFloat("MasterVolume", _lastVolume);
        }
    }
}
