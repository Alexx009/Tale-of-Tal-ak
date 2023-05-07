using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursurOnOff : MonoBehaviour
{

    // Update is called once per frame
    bool isCursorVisible = true;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            isCursorVisible = !isCursorVisible;
            Cursor.lockState = isCursorVisible ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = isCursorVisible;
        }
    }

}
