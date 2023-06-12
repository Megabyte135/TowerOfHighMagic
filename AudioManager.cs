using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioListener))]
[RequireComponent(typeof(SettingsManager))]
public class AudioManager : MonoBehaviour
{
    [HideInInspector]public float GeneralVolume;
    [HideInInspector]public float MusicVolume;
    [HideInInspector]public float EffectVolume;
    public AudioSource Music;
    public AudioSource Effect;
    public SettingsManager SettingsManager;
    static AudioManager _instance = null;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance == this)
        {
            Destroy(gameObject);
        }
        SettingsManager = GetComponent<SettingsManager>();
        GeneralVolume = SettingsManager.Settings.Audio.GeneralVolume;
        MusicVolume = SettingsManager.Settings.Audio.MusicVolume;
        EffectVolume = SettingsManager.Settings.Audio.EffectVolume;
        if (Music != null)
        {
            PlayMusic();
        }
    }

    void Update()
    {
        GeneralVolume = SettingsManager.Settings.Audio.GeneralVolume;
        MusicVolume = SettingsManager.Settings.Audio.MusicVolume;
        EffectVolume = SettingsManager.Settings.Audio.EffectVolume;
        if (Music != null)
        {
            Music.volume = GeneralVolume * MusicVolume;
        }
        if (Effect != null)
        {
            Effect.volume = MusicVolume * EffectVolume;
        }
    }

    public void PlayMusic()
    {
        Play(Music);
    }

    public void PlayEffect()
    {
        Play(Effect);
    }

    void Play(AudioSource audio)
    {
        audio.Play();
    }

}
