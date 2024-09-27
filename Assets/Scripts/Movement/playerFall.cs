using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class playerFall : MonoBehaviour
{
    private Vector3 respawnPoint;
    public loadingScript loadingScript;

    [SerializeField] private Settings_Script pause;
    [SerializeField] private GameObject playerHud;
    public playerHealth playerHealth;
    public GameObject deadText;

    private void Start()
    {
        
        // Get the respawn point from PlayerPrefs
        respawnPoint = new Vector3(
            PlayerPrefs.GetFloat("RespawnX"),
            PlayerPrefs.GetFloat("RespawnY"),
            PlayerPrefs.GetFloat("RespawnZ"));
    }

private IEnumerator RespawnAfterDelay(Vector3 respawnPoint, float delay)
{
    yield return new WaitForSeconds(delay);
    transform.position = respawnPoint;
    playerHud.SetActive(true);
    
}
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("lava"))
        {
            playerDead();
            
        }
    }

    public void playerDead(){
            deadText.SetActive(true);
            Debug.Log("dead");
            playerHud.SetActive(false);
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
               
                StartCoroutine(RespawnAfterDelay(respawnPoint, 1.5f)); 
                 playerHealth.returnDead(); 
            }
    }

}
