using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _coin;
    [SerializeField] private AudioSource _clock;
    [SerializeField] private AudioSource _swim;
    [SerializeField] private AudioSource _swing;

    public static SoundManager Instance;

    private bool _swimSoundEnabled = false;

    private void Start()
    {
        if (!Instance)
            Instance = this;
    }

    public void PlayCoinSound()
    {
        _coin.pitch = Random.Range(0.75f, 1.25f);
        _coin.Play();     
    }

    public void PlayClockSound()
    {
        _clock.pitch = Random.Range(0.75f, 1.25f);
        _clock.Play();
    }

    public void PlaySwingSound()
    {
        _swing.pitch = Random.Range(0.75f, 1.25f);
        _swing.Play();
    }
    public void SwimSound(bool enable)
    {
        if (_swimSoundEnabled == enable)
            return;

        _swimSoundEnabled = enable;

        if (_swimSoundEnabled)
        {
            _swim.pitch = Random.Range(0.75f, 1.25f);
            _swim.Play();
        }
        else
        {
            _swim.Stop();
        }
    }
}
