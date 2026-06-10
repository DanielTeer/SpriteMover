using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettingsManager : MonoBehaviour
{
    public AudioMixer mixer;

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    void Awake()
    {
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    void Start()
    {
        Invoke(nameof(InitAudio), 0.05f);
    }

    void InitAudio()
    {
        SetMasterVolume(masterSlider.value);
        SetMusicVolume(musicSlider.value);
        SetSFXVolume(sfxSlider.value);
    }

    public void SetMasterVolume(float value)
    {
        ApplyVolume("MasterVolume", value);
    }

    public void SetMusicVolume(float value)
    {
        ApplyVolume("MusicVolume", value);
    }

    public void SetSFXVolume(float value)
    {
        ApplyVolume("SFXVolume", value);
    }

    private void ApplyVolume(string paramName, float value)
    {
        float db;

        if (value <= 0.0001f)
        {
            db = -80f;
        }
        else
        {
            db = Mathf.Log10(value) * 20f;
        }

        mixer.SetFloat(paramName, db);
    }
}