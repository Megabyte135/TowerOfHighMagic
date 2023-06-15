using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioListener))]
[RequireComponent(typeof(SettingsManager))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;
    [HideInInspector]public float GeneralVolume;
    [HideInInspector]public float MusicVolume;
    [HideInInspector]public float EffectVolume;
    public AudioSource Music;
    SettingsManager _settingsManager;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
        _settingsManager = SettingsManager.instance;
        GeneralVolume = _settingsManager.Settings.Audio.GeneralVolume;
        MusicVolume = _settingsManager.Settings.Audio.MusicVolume;
        EffectVolume = _settingsManager.Settings.Audio.EffectVolume;
        if (Music != null)
        {
            PlayMusic(Music);
        }
    }

    void Update()
    {
        GeneralVolume = _settingsManager.Settings.Audio.GeneralVolume;
        MusicVolume = _settingsManager.Settings.Audio.MusicVolume;
        EffectVolume = _settingsManager.Settings.Audio.EffectVolume;
    }

    public void PlayMusic(AudioSource music)
    {
        music.volume = GeneralVolume*MusicVolume;
        Play(music);
    }

    public void PlayEffect(AudioSource effect)
    {
        Debug.Log("звук прикольный");
        effect.volume = GeneralVolume * EffectVolume;
        Play(effect);
    }

    void Play(AudioSource audio)
    {
        audio.Play();
    }

}
