using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettingsUI : MonoBehaviour
{
    [Header("Mixer and Sliders")]
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVol", 1f);
        musicSlider.value  = PlayerPrefs.GetFloat("MusicVol", 1f);
        sfxSlider.value    = PlayerPrefs.GetFloat("SFXVol", 1f);
        
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        
        SetMasterVolume(masterSlider.value);
        SetMusicVolume(musicSlider.value);
        SetSFXVolume(sfxSlider.value);
    }
    
    void SetMasterVolume(float linear)
    {
        mixer.SetFloat("MasterVolume", LinearToDecibel(linear));
        PlayerPrefs.SetFloat("MasterVol", linear);
    }

    void SetMusicVolume(float linear)
    {
        mixer.SetFloat("MusicVolume", LinearToDecibel(linear));
        PlayerPrefs.SetFloat("MusicVol", linear);
    }

    void SetSFXVolume(float linear)
    {
        mixer.SetFloat("SFXVolume", LinearToDecibel(linear));
        PlayerPrefs.SetFloat("SFXVol", linear);
    }
    
    // Converts linear volume to decibel scale
    float LinearToDecibel(float linear)
    {
        if (linear <= 0.0001f) return -80f;
        return 20f * Mathf.Log10(linear);
    }
    
}
