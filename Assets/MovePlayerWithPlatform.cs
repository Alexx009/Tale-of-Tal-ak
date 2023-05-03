using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerWithPlatform : MonoBehaviour
{
    private GameObject movingPlatform;
    private bool isOnPlatform = false;
    private Vector3 lastPlatformPosition;
    public CharacterController controller;
private void Start() {
     controller = GetComponent<CharacterController>();
}
private void FixedUpdate()
{
    if (isOnPlatform)
    {
        // Move the player with the platform
        Vector3 move = movingPlatform.transform.position - lastPlatformPosition;
        controller.Move(move);
    }
    lastPlatformPosition = movingPlatform.transform.position;
}

private void OnTriggerEnter(Collider other)
{
    if (other.gameObject.CompareTag("MovingPlatform"))
    {
        isOnPlatform = true;
        movingPlatform = other.gameObject;
        lastPlatformPosition = movingPlatform.transform.position;
    }
}
private void OnTriggerExit(Collider other)
{
    if (other.gameObject.CompareTag("MovingPlatform"))
    {
        isOnPlatform = false;
        movingPlatform = null;
    }
}
}
