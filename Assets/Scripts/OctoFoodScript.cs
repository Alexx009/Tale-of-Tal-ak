using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctoFoodScript : MonoBehaviour
{   
    public GameObject objectToSpawn; // The object we want to spawn
    public GameObject indicatorPrefab; // The visual indicator prefab
    public float objectLifetime = 3.0f; // The lifetime of the spawned object
    public GameObject player; // The player object
    public GameObject indicator; // The instantiated visual indicator object
    private bool isSpawning = false; // Whether an object is currently being spawned
    private float spawnTimer = 0f; // Timer for spawning objects

    private GateCloser gateCloserScript;

    [SerializeField] private GameObject octolandGO;

    [SerializeField] private GameObject bossHealth;
    [SerializeField] private GameObject mainBoss;
    

    void Start() {
        gateCloserScript = GameObject.Find("GateCloseTrigger").GetComponent<GateCloser>();

        // Instantiate the visual indicator object and hide it
        indicator = Instantiate(indicatorPrefab, transform.position, Quaternion.identity);
        isSpawning = false;
        indicator.SetActive(false);
        
    }

    void Update()
    {
        if (!isSpawning) {
            // Increment the spawn timer
            spawnTimer += Time.deltaTime;

            // If the spawn timer reaches the desired delay, spawn an object
            if (spawnTimer >= Random.Range(2f, 4f)) {
                SpawnObject();
                spawnTimer = 0f;
            }
        }

        if(gateCloserScript.isDoorClose){
            StartCoroutine(OctolandQuest());
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "octoFoodLand") {
            // Set the spawn position to the collision point
            Vector3 spawnPosition = collision.contacts[0].point;
            bossHealth.SetActive(true);
            mainBoss.SetActive(true);

            // Move the spawn indicator game object to the spawn position, just above the ground
            indicator.transform.position = new Vector3(spawnPosition.x, 0.1f, spawnPosition.z);

            // Activate the visual indicator
            indicator.SetActive(true);
            Debug.Log("spawn");
        }
    }

    void OnCollisionExit(Collision collision) {
        if (collision.gameObject.tag == "octoFoodLand") {
            // Deactivate the visual indicator
            indicator.SetActive(false);
            Debug.Log("not spawn");
        }
    }

    public void SpawnObject()
    {
        // Set isSpawning to true to prevent multiple objects from being spawned simultaneously
        isSpawning = true;

        // Find the position of the player object
        Vector3 playerPosition = player.transform.position;

        // Calculate the position to spawn the new object at
        Vector3 spawnPosition = playerPosition - new Vector3(0, 50f, 0);

        // Activate the visual indicator
        indicator.SetActive(true);

        // Move the spawn indicator game object to the spawn position, just above the ground
        indicator.transform.position = new Vector3(spawnPosition.x, .5f, spawnPosition.z);

        // Delay spawning the object for 1 second
        StartCoroutine(DelayedSpawn(spawnPosition));
    }

    private IEnumerator DelayedSpawn(Vector3 spawnPosition)
    {
        yield return new WaitForSeconds(1f);

        // Spawn a new object at the spawn position
        GameObject newObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.Euler(0f, 0f, 0f));

        // Set the y position of the spawned object to be the same as the spawnPosition
        Vector3 newPosition = newObject.transform.position;
        newPosition.y = spawnPosition.y;
        newObject.transform.position = newPosition;

        // Animate the new object using LeanTween
        LeanTween.moveLocalY(newObject, 0f, 1f).setEase(LeanTweenType.linear);
        yield return new WaitForSeconds(2); // Pause for 2 seconds
        // Animate the disappearance using LeanTween
        LeanTween.moveLocalY(newObject, -30F, 2f).setEase(LeanTweenType.linear).setDelay(objectLifetime - 1f);

        // Destroy the spawned object after a delay
        Destroy(newObject, objectLifetime);

        // Set isSpawning back to false
        isSpawning = false;
    }

    IEnumerator OctolandQuest(){
        yield return new WaitForSeconds(2);
        octolandGO.SetActive(true);
    }


}
