using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DolphinChildOfCamera : MonoBehaviour
{
    private Transform mainCameraTransform; // reference to the main camera transform
    public Transform dolphinTransform; // reference to the dolphin transform
    private bool isRiding; // flag to indicate if the player is currently riding the dolphin

    private void Start()
    {
        mainCameraTransform = Camera.main.transform;
        dolphinTransform = transform;
    }

    private void FixedUpdate()
    {
        // Check if the player is riding the dolphin
        if (isRiding)
        {
            // Set the dolphin's parent to the main camera
            dolphinTransform.SetParent(mainCameraTransform);

            // Set the dolphin's position and rotation relative to the camera
            dolphinTransform.localPosition = new Vector3(0f, 0.5f, 1f);
            dolphinTransform.localRotation = Quaternion.identity;
        }
        else
        {
            // If the player is not riding the dolphin, remove the dolphin's parent
            dolphinTransform.SetParent(null);
        }
    }

    public void SetIsRiding(bool value)
    {
        // Set the isRiding flag based on the value passed in
        isRiding = value;
    }
}