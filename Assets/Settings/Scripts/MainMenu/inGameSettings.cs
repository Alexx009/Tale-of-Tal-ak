using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class inGameSettings : MonoBehaviour
{

    public LeanTweenType inType;
    bool settingsOpen = true;

    public RectTransform settingsPanelRect;

    public Settings_Script settings;
    // Get a reference to the Image component
    public Image bgImage;

    private void Start()
    {
        settingsPanelRect.LeanMoveX(2000, 0.01f).setEase(inType);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (settingsOpen)
            {
                Cursor.visible = true;
                StartCoroutine(SettingsOpen());
            }
            if (!settingsOpen)
            {
                Cursor.visible = false;
                StartCoroutine(SettingsClose());
            }
        }
    }

    IEnumerator SettingsOpen()
    {

        Cursor.lockState = CursorLockMode.None;
        // Open the settings
        settings.togglePause();
        settingsPanelRect.LeanMoveX(0, 0.5f).setEase(inType);

        // Get the current color of the image
        Color color = bgImage.color;

        // Set the alpha value of the color to 0.5f (50% transparency)
        color.a = 0.5f;

        // Set the modified color back to the image
        bgImage.color = color;

        yield return new WaitUntil(() => settingsPanelRect.anchoredPosition.x == 0);
        settingsOpen = false;
    }

    public IEnumerator SettingsClose()
    {
        settings.togglePause();
        settingsPanelRect.LeanMoveX(2000, 0.5f).setEase(inType);

        // Get the current color of the image
        Color color = bgImage.color;
        // Set the alpha value of the color to 0.5f (50% transparency)
        color.a = 0f;

        // Set the modified color back to the image
        bgImage.color = color;

        yield return new WaitUntil(() => settingsPanelRect.anchoredPosition.x == 2000);
        Cursor.lockState = CursorLockMode.Locked;
        settingsOpen = true;
    }
    public void Close()
    {
        StartCoroutine(SettingsClose());
    }
}
