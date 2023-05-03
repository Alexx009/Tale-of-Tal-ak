using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleHit : MonoBehaviour
{
    public float knockbackForce = 10f;
    public float knockbackDuration = 0.5f;

    private CharacterController characterController;
    private Vector3 knockbackDirection;
    private float knockbackEndTime;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("tentacle"))
        {
            // Calculate the direction of the knockback
            knockbackDirection = transform.position - other.transform.position;
            knockbackDirection.y = 0f;
            knockbackDirection.Normalize();

            // Set the knockback end time
            knockbackEndTime = Time.time + knockbackDuration;
        }
    }

    private void Update()
    {
        if (Time.time < knockbackEndTime)
        {
            // Apply the knockback force to the character controller
            characterController.Move(knockbackDirection * knockbackForce * Time.deltaTime);
        }
    }
}
