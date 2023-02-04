using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [Header("Options Panal")]
    public GameObject optionsPanal;


   

    [Header("Resolution")]
    public TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResultionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width+ " x " + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResultionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResultionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
    public void OptionsMenu()
    {
        if (optionsPanal.activeSelf)
        {
            optionsPanal.SetActive(false);
        } 
        else
        {
            optionsPanal.SetActive(true);
        }
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        print($"Current Resultion Index: {resolutionIndex}");
    }

    public void SetFullScreen(bool isFullscreen)
    { 
        Screen.fullScreen = isFullscreen;
        print($"isFullscreen: {isFullscreen}");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
