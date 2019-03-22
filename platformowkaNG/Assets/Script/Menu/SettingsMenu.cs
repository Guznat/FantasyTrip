using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer musicAudioMixer;
    public AudioMixer sfxAudioMixer;
    public AudioMixer ambientAudioMixer;
    public Button backBtn;

    private void Start()
    {
        backBtn = GetComponent<Button>();
    }

    public void SetMusicVolume(float volume)
    {
        musicAudioMixer.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        sfxAudioMixer.SetFloat("SFXVolume", volume);
    }
    public void SetAmbientVolume(float volume)
    {
        ambientAudioMixer.SetFloat("ambientVolume", volume);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

}
