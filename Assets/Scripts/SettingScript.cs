using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField]
    public AudioMixer audioMixer;
    [SerializeField]
    public Slider sliderVolume;
    [SerializeField]
    public TMPro.TMP_Dropdown dropdown;
    [SerializeField]
    private Button button;

    private Resolution[] resolutions;
    private int currentResolutionIndex = 0;

    void Start()
    {
        // Ob?ine rezolu?iile suportate ale ecranului ?i le adaug? în dropdown
        resolutions = Screen.resolutions;
        dropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            // Verific? rezolu?ia curent?
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        dropdown.AddOptions(options);
        dropdown.value = currentResolutionIndex;
        dropdown.RefreshShownValue();
    }

    public void SetVolume()
    {
        float volume = sliderVolume.value;
        audioMixer.SetFloat("MyExposedParam", (float)(Math.Log10(volume) * 20));

    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void GoToMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}