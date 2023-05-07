using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ChangeColorOnTrigger : MonoBehaviour
{
    public Color greenColor; // the color to change the material to when the player is standing on top of it

    private Renderer renderers;
    private Color originalColor;
    private bool playerIsOnTop = false;

    private void Start()
    {
        renderers = GetComponent<Renderer>();
        originalColor = renderers.material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsOnTop = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsOnTop = true;

            // Check if the character controller is on top of the object
            CharacterController characterController = other.GetComponent<CharacterController>();
            if (characterController != null && characterController.isGrounded)
            {
                renderers.material.color = greenColor;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsOnTop = false;
            renderers.material.color = originalColor;
        }
    }

    private void Update()
    {
        // Check if the player is still on top of the object
        if (playerIsOnTop && !GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>().bounds.Intersects(GetComponent<Collider>().bounds))
        {
            playerIsOnTop = false;
            renderers.material.color = originalColor;
        }
    }
}