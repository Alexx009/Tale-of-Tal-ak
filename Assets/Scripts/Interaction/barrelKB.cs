using UnityEngine;

public class barrelKB : MonoBehaviour
{
    [SerializeField] private float knockbackForce = 5f;
    [SerializeField] private float knockbackDuration = 0.5f;
    private float knockbackTimer = 0f;

    private CharacterController controller;
    private Vector3 knockbackDirection;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void OnCollisionEnter(Collision other)
    {
        // Check if the collision was with a "hazard" object
        if (other.gameObject.CompareTag("barrel"))
        {
            // Calculate the knockback direction
            knockbackDirection = (transform.position - other.transform.position).normalized;

            // Set the knockback timer to the specified duration
            knockbackTimer = knockbackDuration;
        }
    }

    private void Update()
    {
        // Reduce the knockback timer over time
        if (knockbackTimer > 0)
        {
            knockbackTimer -= Time.deltaTime;

            // Apply the knockback force to the player's position using the CharacterController
            controller.Move(knockbackDirection * knockbackForce * Time.deltaTime);
        }
    }
}
