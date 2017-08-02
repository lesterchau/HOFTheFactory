using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SettingsManager : MonoBehaviour
{

    public Toggle fullscreenToggle;
    public Dropdown resolutionDropdown;
    public Dropdown textureQualityDropdown;
    public Dropdown antialiasingDropdown;
    public Dropdown vSyncDropdown;
    public Slider musicVolumeSlider;
    public Slider SFXVolumeSlider;
    public Button applyButton;

    public AudioSource musicSource;
    public AudioSource[] SFXSources;

    public Resolution[] resolutions;
    public GameSettings gameSettings;

    public PauseMenu menu;
    // Use this for initialization
    void OnEnable()
    {

        gameSettings = new GameSettings();

        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullscreenToggle(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        textureQualityDropdown.onValueChanged.AddListener(delegate { OnTextureQualityChange(); });
        antialiasingDropdown.onValueChanged.AddListener(delegate { OnAntialiasingChange(); });
        vSyncDropdown.onValueChanged.AddListener(delegate { OnVSyncChange(); });
        musicVolumeSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChanged(); });
        SFXVolumeSlider.onValueChanged.AddListener(delegate { OnSFXVolumeChanged(); });
        applyButton.onClick.AddListener(delegate { onApplyButtonPress(); });

        resolutions = Screen.resolutions;

        foreach (Resolution resolution in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }

        try
        {
            loadSettings();
        }
        catch
        {
            musicVolumeSlider.value = 1;
            antialiasingDropdown.value = QualitySettings.antiAliasing;
            vSyncDropdown.value = QualitySettings.vSyncCount;
            textureQualityDropdown.value = QualitySettings.masterTextureLimit;
            fullscreenToggle.isOn = Screen.fullScreen;
        }
    }

    public void OnFullscreenToggle()
    {
        gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
    }

    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
        gameSettings.resolutionIndex = resolutionDropdown.value;
        resolutionDropdown.RefreshShownValue();
    }

    public void OnTextureQualityChange()
    {
        QualitySettings.masterTextureLimit = gameSettings.textureQuality = textureQualityDropdown.value;
    }

    public void OnAntialiasingChange()
    {
        gameSettings.antialiasing = QualitySettings.antiAliasing = (int)Mathf.Pow(2, antialiasingDropdown.value);
    }

    public void OnVSyncChange()
    {
        QualitySettings.vSyncCount = gameSettings.vSync = vSyncDropdown.value;
    }

    public void OnMusicVolumeChanged()
    {
        musicSource.volume = gameSettings.musicVolume = musicVolumeSlider.value;
    }

    public void OnSFXVolumeChanged()
    {
        gameSettings.SFXVolume = SFXVolumeSlider.value;
        foreach(AudioSource source in SFXSources)
        {
            source.volume = SFXVolumeSlider.value;
        }
    }

    public void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(gameSettings, true);
        File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jsonData);
    }

    public void onApplyButtonPress()
    {
        SaveSettings();
        menu.exitOptions();
    }

    public void loadSettings()
    {
        gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));

        musicVolumeSlider.value = gameSettings.musicVolume;
        antialiasingDropdown.value = gameSettings.antialiasing;
        vSyncDropdown.value = gameSettings.vSync;
        textureQualityDropdown.value = gameSettings.textureQuality;
        resolutionDropdown.value = gameSettings.resolutionIndex;
        fullscreenToggle.isOn = gameSettings.fullscreen;

        resolutionDropdown.RefreshShownValue();
    }

}

