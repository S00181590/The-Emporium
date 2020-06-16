using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameOptions gameOptions;

    public Toggle fullScreenToggle;
   // public Toggle VSyncEnabled;
    public Dropdown ResoulionDropDownSettings;
    public Dropdown TextureDetailsSettings;
   // public Dropdown DayTimeCycle;
    public Slider MusicVolumeSlider;

    public Resolution[] resolutions;//storeing al resolutions to be retunred
    public Button buttonApply;
    public AudioSource MusicSources;

     void OnEnable()
    {
        gameOptions = new GameOptions();

        fullScreenToggle.onValueChanged.AddListener(delegate { EnableFullScreen(); });
        ResoulionDropDownSettings.onValueChanged.AddListener(delegate { setResolution(); });
        TextureDetailsSettings.onValueChanged.AddListener(delegate { setTextureQuailty(); });
        MusicVolumeSlider.onValueChanged.AddListener(delegate { SettingtheVolume(); });
        buttonApply.onClick.AddListener(delegate { OnButtonApplyClick(); });
       // VSyncEnabled.onValueChanged.AddListener(delegate { EnableVSync(); });

        ResoulionDropDownSettings.ClearOptions();
        List<string> resoultionOptions = new List<string>();
        resolutions = Screen.resolutions;

        foreach (Resolution resolution in resolutions)
        {
            ResoulionDropDownSettings.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }
        LoadSettings();
    }

    public void setResolution()
    {
        Screen.SetResolution(resolutions[ResoulionDropDownSettings.value].width, resolutions[ResoulionDropDownSettings.value].height, Screen.fullScreen);
        gameOptions.Resolutionindex = ResoulionDropDownSettings.value;
    }

    public void setTextureQuailty()
    {
        QualitySettings.masterTextureLimit = TextureDetailsSettings.value;
    }

    public void SettingtheVolume()
    {
        MusicSources.volume = gameOptions.MusicVolume = MusicVolumeSlider.value;
    }

    public void EnableFullScreen()
    {
        gameOptions.FullScreen = Screen.fullScreen = fullScreenToggle.isOn;
    }

    //public void EnableVSync()
    //{
    //    gameOptions.VSync = VSyncEnabled.enabled = VSyncEnabled;
    //}

    public void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(gameOptions, true);
        File.WriteAllText(Application.persistentDataPath + "gamesttings.json", jsonData);
    }
    public void OnButtonApplyClick()
    {
        SaveSettings();
    }
    public void LoadSettings()
    {
        gameOptions = JsonUtility.FromJson<GameOptions>(File.ReadAllText(Application.persistentDataPath + "/gamesttings.json"));
        MusicVolumeSlider.value = gameOptions.MusicVolume;
        ResoulionDropDownSettings.value = gameOptions.Resolutionindex;
        TextureDetailsSettings.value = gameOptions.TextureQuality;
        fullScreenToggle.isOn = gameOptions.FullScreen;
        Screen.fullScreen = gameOptions.FullScreen;
        ResoulionDropDownSettings.RefreshShownValue();

        ////might have to change 
        //VSyncEnabled.isOn = gameOptions.VSync;
        //VSyncEnabled.enabled = gameOptions.VSync;
    }
}

