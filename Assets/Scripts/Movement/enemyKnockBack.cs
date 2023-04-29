using UnityEngine;

public class enemyKnockBack : MonoBehaviour
{
    public float kbForce = 10f;
    public float knockbackDistanceThreshold = 5f;
    private float kbTimer = 0f;
    private Vector3 kbDirection;
    private CharacterController characterController;

    private void Start()
    {
        // Get the CharacterController component
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (kbTimer > 0)
        {
            // Move the object in the knockback direction
            characterController.Move(kbDirection * kbForce * Time.deltaTime);

            // Reduce the knockback timer
            kbTimer -= Time.deltaTime;
        }
    }

    public void EnemyKnockBack(Vector3 knockbackDirection)
    {
        // Apply the knockback force to the enemy's CharacterController
        if (characterController != null)
        {
            float distance = Vector3.Distance(transform.position, knockbackDirection);
            float knockbackForceScaled = kbForce * Mathf.Clamp01(1f - distance / knockbackDistanceThreshold);
            kbDirection = -knockbackDirection.normalized;
            kbTimer = 0.1f;
        }
    }
}
