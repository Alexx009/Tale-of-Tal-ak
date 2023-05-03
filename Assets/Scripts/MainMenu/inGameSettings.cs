using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inGameSettings : MonoBehaviour
{

    public LeanTweenType inType;
    bool settingsOpen = false;

    public RectTransform settingsPanelRect;

    private void Start() {
        settingsPanelRect.LeanSetPosX(2000);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (settingsOpen) {
                // Close the settings
                settingsClose();
            } else {
                // Open the settings
                
                settingsPanelRect.LeanMoveX(0, 1).setEase(inType);
                settingsOpen = true;
            }
        }
    }

    public void settingsClose(){
        settingsPanelRect.LeanMoveX(2000, 1).setEase(inType);
        settingsOpen = false;
    }

}
