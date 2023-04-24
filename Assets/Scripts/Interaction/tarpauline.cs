using UnityEngine;

public class tarpauline : MonoBehaviour
{
    public float launchForce = 10f; // The force to launch the player
    public float bounceFactor = 0.5f; // The factor that determines how much the player bounces
    public CharacterController playerController; // The player's CharacterController component

    private bool isLaunching = false; // Whether the player is currently being launched
    private Vector3 launchForceVector; // The launch force to apply to the player
    private float launchStartTime; // The time when the launch sequence started
    private float launchDuration = 1f; // The duration of the launch sequence in seconds
    private float launchHeight = 2f; // The maximum height the player should reach during the launch sequence

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("launch");
        // Check if the player enters a trigger zone
        if (other.gameObject.CompareTag("Player"))
        {
            // Calculate the launch force
            Vector3 launchDirection = Vector3.up;
            launchForceVector = launchDirection.normalized * launchForce;

            // Start the launch sequence
            isLaunching = true;
            launchStartTime = Time.time;
        }
    }

    private void Update()
    {
        // If the player is being launched, apply the launch force and bounce effect over time
        if (isLaunching)
        {
            Debug.Log("is launching");
            // Calculate the time elapsed since the launch sequence started
            float launchTime = Time.time - launchStartTime;

            // Apply the launch force and bounce effect
            playerController.Move(launchForceVector * Time.deltaTime);
            playerController.Move(-launchForceVector * (launchForce * bounceFactor) * Time.deltaTime);

            // Check if the player has reached the maximum height or if the launch duration has passed
            if (playerController.transform.position.y >= launchHeight || launchTime >= launchDuration)
            {
                // End the launch sequence
                isLaunching = false;
            }
        }
    }
}
