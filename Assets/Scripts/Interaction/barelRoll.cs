using UnityEngine;
using System.Collections;

public class barelRoll : MonoBehaviour
{
    public GameObject objectPrefab;
    public Transform spawnPoint;

    private bool isSpawning = false;

    public float randMinSpawn;
    public float randMaxSpawn;
    public float randMinSpeed;
    public float randMaxSpeed;

    public float randMinWait;
    public float randMaxWait;

    private void Update()
    {
        // Check if an object is already being spawned
        if (!isSpawning)
        {
            float randomValue = Random.Range(randMinSpawn, randMaxSpawn);

            if (randomValue <= 2)
            {
                isSpawning = true;
                StartCoroutine(SpawnObject());
            }
        }
    }


    
    IEnumerator SpawnObject()
    {
        float randomValue = Random.Range(randMinSpeed, randMaxSpeed);
        float randomWait = Random.Range(randMinWait, randMaxWait);

        GameObject newObject = Instantiate(objectPrefab, spawnPoint.position, spawnPoint.rotation);

        Rigidbody rb = newObject.GetComponent<Rigidbody>();
        newObject.LeanRotateZ(90, 0);

        if (rb != null)
        {
            rb.AddForce(transform.forward * randomValue, ForceMode.Impulse);
        }
        yield return new WaitForSeconds(randomWait);
        // Set the flag variable to false to allow spawning of a new object
        isSpawning = false;

        yield return new WaitForSeconds(3f);
        Destroy(newObject);
    }
}
