using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSounds : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] _stepSounds;
    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void PlayFootstepSound()
    {
        if (_stepSounds.Length>0)
        {
            int r = Random.Range(0, _stepSounds.Length);
            _audioSource.PlayOneShot(_stepSounds[r]);
        }
    }
}
