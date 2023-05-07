using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class inGameSettings : MonoBehaviour
{

    public LeanTweenType inType;
    bool settingsOpen = false;
    bool isCursorVisible = true;

    public RectTransform settingsPanelRect;

    public Settings_Script settings;

    public Image bgImage;

    private EventSystem eventSystem;

    private void Start()
    {
        settingsPanelRect.LeanSetPosX(2000);
        eventSystem = FindObjectOfType<EventSystem>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsOpen)
            {
                // Close the settings
                settingsClose();
            }
            else
            {
                // Open the settings
                settings.togglePause();
                settingsPanelRect.LeanMoveX(0, 0.5f).setEase(inType);
                settingsOpen = true;
                // Disable the EventSystem to make UI interactable
                eventSystem.enabled = false;
                // Lock the cursor when the settings panel is open
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                // Get the current color of the image
                Color color = bgImage.color;
                // Set the alpha value of the color to 0.5f (50% transparency)
                color.a = 0.5f;
                // Set the modified color back to the image
                bgImage.color = color;
            }
        }
    }

    public void settingsClose()
    {
        settings.togglePause();
        settingsPanelRect.LeanMoveX(2000, 0.5f).setEase(inType);
        settingsOpen = false;
        // Enable the EventSystem to make UI interactable
        eventSystem.enabled = true;
        // Unlock the cursor when the settings panel is closed
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        // Get the current color of the image
        Color color = bgImage.color;
        // Set the alpha value of the color to 0f (fully transparent)
        color.a = 0f;
        // Set the modified color back to the image
        bgImage.color = color;
    }
}
