using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DolphinController : MonoBehaviour
{
   // private float turnSpeed = 100f;
    public Camera playerCamera;
    public float moveSpeed = 100f;
    private DolphinController dolphinController;

private void Start()
{
    dolphinController = GetComponent<DolphinController>();
}

private void FixedUpdate()
{
    if (dolphinController.enabled)
    {
        // Get the player's input.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Move the dolphin.
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        transform.position += moveDirection * dolphinController.moveSpeed * Time.deltaTime;
  
//     if (playerCamera != null)
// {
//     Vector3 cameraForward = playerCamera.transform.forward;
//     cameraForward.y = 0f; // ignore the camera's vertical rotation
//     Quaternion targetRotation = Quaternion.LookRotation(cameraForward);
//     transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
// }
    }
}
}