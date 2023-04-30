using UnityEngine;

public class playerFall : MonoBehaviour
{
    private Vector3 respawnPoint;

    private void Start()
    {
        // Get the respawn point from PlayerPrefs
        respawnPoint = new Vector3(
            PlayerPrefs.GetFloat("RespawnX"),
            PlayerPrefs.GetFloat("RespawnY"),
            PlayerPrefs.GetFloat("RespawnZ"));

        
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.R)){
            Debug.Log("respawn");
            // Get the respawn point position from PlayerPrefs
            Vector3 respawnPoint = new Vector3(
                PlayerPrefs.GetFloat("RespawnX"),
                PlayerPrefs.GetFloat("RespawnY"),
                PlayerPrefs.GetFloat("RespawnZ")
            );
            // Respawn the player at the last save point
            transform.position = respawnPoint;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("lava"))
        {
            Debug.Log("respawn");
            // Get the respawn point position from PlayerPrefs
            Vector3 respawnPoint = new Vector3(
                PlayerPrefs.GetFloat("RespawnX"),
                PlayerPrefs.GetFloat("RespawnY"),
                PlayerPrefs.GetFloat("RespawnZ")
            );
            // Respawn the player at the last save point
            transform.position = respawnPoint;
        }
    }

}
