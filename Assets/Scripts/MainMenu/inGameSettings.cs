using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inGameSettings : MonoBehaviour
{

    public LeanTweenType inType;
    bool settingsOpen = false;

    public RectTransform settingsPanelRect;

    public Settings_Script settings;
// Get a reference to the Image component
    public Image bgImage;
    

    private void Start() {
        settingsPanelRect.LeanSetPosX(2000);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.lockState = CursorLockMode.None;
            if (settingsOpen) {
                // Close the settings
                settingsClose();
            } else {
                // Open the settings
                settings.togglePause();
                settingsPanelRect.LeanMoveX(0, 0.5f).setEase(inType);
                settingsOpen = true;
                // Get the current color of the image
                Color color = bgImage.color;

                // Set the alpha value of the color to 0.5f (50% transparency)
                color.a = 0.5f;

                // Set the modified color back to the image
                bgImage.color = color;
            }
        }
    }

    public void settingsClose(){
        settings.togglePause();
        settingsPanelRect.LeanMoveX(2000, 0.5f).setEase(inType);
        settingsOpen = false;
        Cursor.lockState = CursorLockMode.Locked;
        // Get the current color of the image
        Color color = bgImage.color;

        // Set the alpha value of the color to 0.5f (50% transparency)
        color.a = 0f;

        // Set the modified color back to the image
        bgImage.color = color;
    }

}
