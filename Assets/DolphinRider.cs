using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DolphinRider : MonoBehaviour
{
    public CharacterController characterController;
    public Rigidbody rb;
    public DolphinController dolphinController;
    public float interactionDistance = 5f; // the distance where player can interact with the dolphin
    public KeyCode rideKey = KeyCode.E; // the key to press to ride the dolphin
    private bool canRide; // flag to indicate if the player can ride the dolphin
    private bool isRiding; // flag to indicate if the player is currently riding the dolphin
    private Camera playerCamera; // reference to the player camera
    private Transform cameraTransform; // reference to the camera transform
    private Transform cameraTarget; // reference to the current camera target (player or dolphin)
    private Transform dolphinBody; // reference to the dolphin body transform
    private DolphinChildOfCamera childOfCameraScript; // Reference to DolphinChildOfCamera script


    private void Start()
    {
        playerCamera = Camera.main;
        cameraTransform = playerCamera.transform;
        cameraTarget = transform;
        dolphinBody = dolphinController.transform.Find("Body");
    }

    private void Update()
    {
        if (canRide && Input.GetKeyDown(rideKey))
        {
            StartRidingDolphin(dolphinController.gameObject);
        }
        else if (isRiding && Input.GetKeyDown(rideKey))
        {
            StopRidingDolphin();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dolphin"))
        {
            canRide = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Dolphin"))
        {
            canRide = false;
            StopRidingDolphin();
        }
    }

   
   private void StartRidingDolphin(GameObject dolphin)
{
    // Disable the player's character controller and turn off gravity.
    characterController.enabled = false;
    rb.useGravity = false;

    // Parent the player to the dolphin and set the player's position and rotation.
    transform.SetParent(dolphin.transform); // Use SetParent method to set the character as the parent of the dolphin
    transform.localPosition = new Vector3(0, 2, 0);
    transform.localRotation = Quaternion.identity;

    // Enable the dolphin controller.
    dolphinController.enabled = true;
    isRiding = true;

    // Enable the dolphin controller and assign the player camera.
    dolphinController.enabled = true;
    dolphinController.playerCamera = playerCamera;

    // Change the camera target to the player object.
    cameraTarget = playerCamera.transform;

    // Set the DolphinChildOfCamera script's dolphinTransform variable to the dolphin's transform.
    childOfCameraScript = playerCamera.GetComponent<DolphinChildOfCamera>();
    if (childOfCameraScript != null)
    {
        childOfCameraScript.dolphinTransform = dolphin.transform;
    }
}

    private void StopRidingDolphin()
    {
        // Unparent the player from the dolphin and reset the player's position and rotation.
        transform.parent = null;
        transform.position = dolphinController.transform.position + new Vector3(0, 1, 0);
        transform.rotation = dolphinController.transform.rotation;

        // Disable the dolphin controller.
        dolphinController.enabled = false;
        isRiding = false;

        // Enable the player's character controller and turn on gravity.
        characterController.enabled = true;
        rb.useGravity = true;

        // Change the camera target back to the player object.
        cameraTarget = transform;
    }

    private void FixedUpdate()
    {
        if (!isRiding && dolphinController.enabled)
        {
            dolphinController.enabled = false;
        }

        // Set the camera position and rotation based on the camera target.
        cameraTransform.position = cameraTarget.position;
        cameraTransform.rotation = Quaternion.LookRotation(cameraTarget.forward, Vector3.up);

        // Make the dolphin's body look where the camera is looking.
        if (dolphinBody != null)
        {
            dolphinBody.rotation = Quaternion.LookRotation(cameraTransform.forward, Vector3.up);
        }
    }
}