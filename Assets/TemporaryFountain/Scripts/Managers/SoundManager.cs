using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _coin;
    [SerializeField] private AudioSource _clock;

    public static SoundManager Instance;

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
}
