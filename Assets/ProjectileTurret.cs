
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTurret : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab; // The projectile prefab to instantiate
    [SerializeField] private Transform spawnPoint; // The position to spawn the projectile from
    [SerializeField] private float projectileForce = 100f; // The force with which to fire the projectile
    [SerializeField] private float fireRate = 1f; // The rate of fire (in seconds)
    private float projectileLifeTime = 5f;

    private float randomTiming;
    [SerializeField] private ParticleSystem warningEffect; // The particle system to use as a warning effect

    private void Start()
    {
        // Start firing projectiles
        StartCoroutine(FireProjectiles());
    }

    private IEnumerator FireProjectiles()
    {
        while (true)
        {
            // Play the warning particle effect
            warningEffect.Play();

            // Wait for a short duration to allow the warning effect to finish
            yield return new WaitForSeconds(randomTiming);

            // Instantiate the projectile prefab at the spawn point position
            GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);

            // Add an impulse force to the projectile in the forward direction of the spawn point
            projectile.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * projectileForce, ForceMode.Impulse);

            // Destroy the projectile after a set amount of time
            Destroy(projectile, projectileLifeTime);

            // Stop the warning particle effect
            warningEffect.Stop();

            // Wait for the specified fire rate before firing the next projectile
            yield return new WaitForSeconds(fireRate);
        }
    }

     private void Update() {
    randomTiming =  Random.Range(5f, 10f);   
    }
}