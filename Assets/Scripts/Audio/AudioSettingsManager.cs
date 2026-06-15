using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettingsManager : MonoBehaviour
{
    public AudioMixer mixer;//labels mixer

    public Slider masterSlider;//slider names
    public Slider musicSlider;
    public Slider sfxSlider;

    void Awake()
    {
        masterSlider.onValueChanged.AddListener(SetMasterVolume);//sets the listener to max
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    void Start()
    {
        Invoke(nameof(InitAudio), 0.05f);//lowes setting to prevent bottom out
    }

    void InitAudio()
    {
        SetMasterVolume(masterSlider.value);// sets default levels
        SetMusicVolume(musicSlider.value);
        SetSFXVolume(sfxSlider.value);
    }

    public void SetMasterVolume(float value)
    {
        ApplyVolume("MasterVolume", value);//takes screen input to mixer
    }

    public void SetMusicVolume(float value)
    {
        ApplyVolume("MusicVolume", value);//takes screen input to mixer
    }

    public void SetSFXVolume(float value)
    {
        ApplyVolume("SFXVolume", value);//takes screen input to mixer
    }

    private void ApplyVolume(string paramName, float value)
    {
        float db;//cals level to db

        if (value <= 0.0001f)
        {
            db = -80f;
        }
        else
        {
            db = Mathf.Log10(value) * 20f;//sets volume in db levels
        }

        mixer.SetFloat(paramName, db);
    }
}