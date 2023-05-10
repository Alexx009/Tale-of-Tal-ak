using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Settings_Script : MonoBehaviour
{
    public TMP_Dropdown dropdown; // Reference to the Dropdown component
    public TextMeshProUGUI text; // Reference to the Text component of the Dropdown's Label
    
    public MouseLook Msens;
    public Toggle fullscreenToggle; // Reference for Toggle


    public AudioMixer audioMixer;   // Reference for audio

    public AudioMixer musicMixer;   // Reference for music

    public MouseLook mouseLook;
    public PlayerGalaw playerGalaw;
    public Animator animator;
    


    private bool isPaused = false;
    
    void Start()
    {
        getReso();

        // Add listener to the toggle
        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullScreen(); });

        // Change Resolution
        dropdown.onValueChanged.AddListener(delegate { OnResChange(); });

        // Set the initial state of the toggle to match the screen's initial full screen state
        fullscreenToggle.isOn = Screen.fullScreen;

    }



// GET AVAILABLE RESOLUTION ON THE DEVICE
    void getReso()
    {
        dropdown.ClearOptions();

        // Get the screen resolution of the device
        int width = Screen.width;
        int height = Screen.height;

        // Get all available resolutions
        Resolution[] resolutions = Screen.resolutions;

        // Add each resolution as a new option to the dropdown list
        foreach (Resolution resolution in resolutions)
        {
            string optionText = resolution.width + " x " + resolution.height;
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData(optionText);
            dropdown.options.Add(option);

            // If the resolution matches the current screen resolution, set it as the default selected option
            if (resolution.width == width && resolution.height == height)
            {
                int optionIndex = dropdown.options.Count - 1;
                dropdown.value = optionIndex;
            }

        }
    }



// RESOLUTION CHANGE
    void OnResChange()
    {
        // Get the selected resolution option
        string selectedOption = dropdown.options[dropdown.value].text;

        // Parse the resolution from the option string
        string[] resolutionParts = selectedOption.Split('x');
        int width = int.Parse(resolutionParts[0].Trim());
        int height = int.Parse(resolutionParts[1].Trim());

        // Set the resolution to the selected option
        Screen.SetResolution(width, height, fullscreenToggle.isOn);
        Debug.Log("My resolution is " + width + " x " + height);
    }


// FULLSCREEN
    void OnFullScreen()
    {
        // Set the full screen state based on the toggle's value
        Screen.fullScreen = fullscreenToggle.isOn;
    }


// VOLUME
    public void setAudio (float volume) {
        audioMixer.SetFloat("volume", volume);
    }



// Music
    public void setMusic (float volume) {
        musicMixer.SetFloat("volume", volume);
    }
// Mouse sensitivity
    public void setMsens (float sens) {
        Msens.mSens = sens;
    }

// QUALITY
    public void setQuality (int qualityIndex) {

        QualitySettings.SetQualityLevel(qualityIndex);
    }


// PAUSE
    public void togglePause() {
        if (isPaused) {
            ResumeGame();
            
        } else {
            Pause();
        }
    }
    public void Pause()
    {
        mouseLook.enabled = false;
        playerGalaw.enabled = false;
        animator.enabled = false;
        isPaused = true;
        Debug.Log("Game paused.");
    }
    public void ResumeGame()
    {
        mouseLook.enabled = true;
        playerGalaw.enabled = true;
        animator.enabled = true;
        isPaused = false;
        Debug.Log("Game resumed.");
    }

    public void restartScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void backToMainMenu(){
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync("mainMenu");
    }
}