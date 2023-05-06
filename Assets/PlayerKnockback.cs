using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockback : MonoBehaviour
{
    [SerializeField] private float knockbackForce = 300f;

    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("tentacle"))
        {
            Vector3 knockbackDirection = transform.position - other.transform.position;
            knockbackDirection.y = 0f;
            controller.Move(knockbackDirection.normalized * knockbackForce * Time.deltaTime);
        }
    }
}
