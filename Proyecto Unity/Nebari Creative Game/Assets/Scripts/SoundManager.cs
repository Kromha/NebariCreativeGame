using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("AudioSources")]
    public AudioSource musicAudioSource;
    public AudioSource fxAudioSource;

    //Music Clips
    [Header("Music Clips")]
    public AudioClip musicMenu;
    public AudioClip musicGameplay;

    //FX Clips
    [Header("Fx Clips")]
    public AudioClip collisionFX;
    public AudioClip paintCollisionFX;
    public AudioClip pickCollisionFX;
    public AudioClip clickFX;
    public AudioClip slowDownFX;
    public AudioClip winFX;
    public AudioClip loseFX;

    [Header("Audio Mixers")]
    public AudioMixerGroup master;
    public AudioMixerGroup FXs;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ToMenuMusic();
    }

    //Music functions
    public void ToMenuMusic()
    {
        musicAudioSource.clip = musicMenu;
        musicAudioSource.loop = true;
        musicAudioSource.Play();
    }

    public void ToGamePlayMusic()
    {
        musicAudioSource.clip = musicGameplay;
        musicAudioSource.loop = true;
        musicAudioSource.Play();
    }

    //FX Functions
    public void playCollision()
    {
        fxAudioSource.clip = collisionFX;
        fxAudioSource.Play();
    }

    public void playBreak()
    {
        fxAudioSource.clip = paintCollisionFX;
        fxAudioSource.Play();
    }

    public void playClickMenu()
    {
        fxAudioSource.clip = clickFX;
        fxAudioSource.Play();
    }

    public void playWinFX()
    {
        fxAudioSource.clip = winFX;
        fxAudioSource.Play();
    }

    public void playSlowDown()
    {
        fxAudioSource.clip = slowDownFX;
        fxAudioSource.Play();
    }

    public void playPick()
    {
        fxAudioSource.clip = pickCollisionFX;
        fxAudioSource.Play();
    }
    public void playLose()
    {
        fxAudioSource.clip = loseFX;
        fxAudioSource.Play();
    }

    public void OnSlowDown()
    {
        musicAudioSource.outputAudioMixerGroup= FXs;
    }

    public void OutSlowDown()
    {
        musicAudioSource.outputAudioMixerGroup = master;
    }
}
