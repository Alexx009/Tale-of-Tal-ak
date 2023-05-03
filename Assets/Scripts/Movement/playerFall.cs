using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class playerFall : MonoBehaviour
{
    private Vector3 respawnPoint;
    public loadingScript loadingScript;

    [SerializeField] private TextMeshProUGUI dead;
    [SerializeField] private TextMeshProUGUI pressR;
    [SerializeField] private Settings_Script pause;
    [SerializeField] private GameObject playerHud;

    private void Start()
    {
        // Get the respawn point from PlayerPrefs
        respawnPoint = new Vector3(
            PlayerPrefs.GetFloat("RespawnX"),
            PlayerPrefs.GetFloat("RespawnY"),
            PlayerPrefs.GetFloat("RespawnZ"));

        
        dead.enabled = false;
        pressR.enabled = false;

    }

private IEnumerator RespawnAfterDelay(Vector3 respawnPoint, float delay)
{
    yield return new WaitForSeconds(delay);
    transform.position = respawnPoint;
}
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("lava"))
        {
            playerHud.SetActive(false);
            dead.enabled = true;
            pressR.enabled = true;
            Debug.Log("respawn");
            Debug.Log("Restarting");
            // Get the respawn point position from PlayerPrefs
            Vector3 respawnPoint = new Vector3(
                PlayerPrefs.GetFloat("RespawnX"),
                PlayerPrefs.GetFloat("RespawnY"),
                PlayerPrefs.GetFloat("RespawnZ")
                );
            pause.Pause();
            if(Input.GetKey(KeyCode.R)){
                StartCoroutine(loadingScript.restartLoad());
                StartCoroutine(RespawnAfterDelay(respawnPoint, 2f));      
            }

            // Respawn the player after a delay of 2 seconds
            
        }
    }

}
