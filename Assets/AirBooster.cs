using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBooster : MonoBehaviour
{   [SerializeField] private GameObject projectilePrefab; // The projectile prefab to instantiate
    [SerializeField] private Transform spawnPoint; // The position to spawn the projectile from
    [SerializeField] private float projectileForce = 10f; // The force with which to fire the projectile
    [SerializeField] private float fireRate = 1f; // The rate of fire (in seconds)
    private float projectileLifeTime = 5f;
    public float knockbackForce = 250f;
    public float knockbackDuration = 0.5f;

    private CharacterController characterController;
    private Vector3 knockbackDirection;
    private float knockbackEndTime;

    public ParticleSystem particleEffect;

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("airGun")){
        StartCoroutine(AirGun());
        }
    }
    private void OnTriggerExit(Collider other) {
       
        if(other.CompareTag("airGun")){
             StopCoroutine(AirGun());
        }
    }

     private IEnumerator AirGun()
    {
        while (true)
        {
            // Play the warning particle effect
            particleEffect.Play();

            // Wait for a short duration to allow the warning effect to finish
            yield return new WaitForSeconds(1.5f);

            // Instantiate the projectile prefab at the spawn point position
            GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);

            // Add an impulse force to the projectile in the forward direction of the spawn point
            projectile.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * projectileForce, ForceMode.Impulse);

            // Destroy the projectile after a set amount of time
            Destroy(projectile, projectileLifeTime);

            // Stop the warning particle effect
            particleEffect.Stop();

            // Wait for the specified fire rate before firing the next projectile
            yield return new WaitForSeconds(10);
        }
    }
}
