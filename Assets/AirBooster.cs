using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AirBooster : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab; // The projectile prefab to instantiate
    [SerializeField] private Transform spawnPoint; // The position to spawn the projectile from
    [SerializeField] private float projectileForce = 5f; // The force with which to fire the projectile
    [SerializeField] private float fireRate = 1f; // The rate of fire (in seconds)
    private float projectileLifeTime = 5f;
    public float knockbackForce = 1500f;
    public float knockbackDuration = 0.5f;

    private CharacterController characterController;
    private Vector3 knockbackDirection;
    private float knockbackEndTime;

    public ParticleSystem particleEffect;

    private bool playerIsPresent = false; // Indicates whether the player is currently in the trigger area

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("airGun"))
        {
            playerIsPresent = true; // Set playerIsPresent to true when the player enters the trigger area
            StartCoroutine(AirGun());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("airGun"))
        {
            playerIsPresent = false; // Set playerIsPresent to false when the player exits the trigger area
            StopCoroutine(AirGun());
        }
    }

    private IEnumerator AirGun()
    {
        while (playerIsPresent) // Only run the coroutine while the player is present
        {
            // Play the warning particle effect
            particleEffect.Play();

            // Wait for a short duration to allow the warning effect to finish
            yield return new WaitForSeconds(3f);

            // Instantiate the projectile prefab at the spawn point position
            GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);

            // Add an impulse force to the projectile in the forward direction of the spawn point
            projectile.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * projectileForce, ForceMode.Impulse);

            // Destroy the projectile after a set amount of time
            Destroy(projectile, projectileLifeTime);

            // Stop the warning particle effect
            particleEffect.Stop();

            // Wait for the specified fire rate before firing the next projectile
            yield return new WaitForSeconds(fireRate);
        }
    }
}