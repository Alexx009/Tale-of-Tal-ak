using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class playerFall : MonoBehaviour
{
    private Vector3 respawnPoint;
    public loadingScript loadingScript;

    [SerializeField] private Settings_Script pause;
    [SerializeField] private GameObject playerHud;
    public playerHealth playerHealth;
    public GameObject deadText;

    public string sceneToReLoad;

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
    deadText.SetActive(false);
    pause.ResumeGame();
    
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
            // Get the respawn point position from PlayerPrefs
            Vector3 respawnPoint = new Vector3(
                PlayerPrefs.GetFloat("RespawnX"),
                PlayerPrefs.GetFloat("RespawnY"),
                PlayerPrefs.GetFloat("RespawnZ")
                );
            pause.Pause();
            if(Input.GetKey(KeyCode.R)){
                
                 SceneManager.LoadSceneAsync(sceneToReLoad);
                // Debug.Log("Resume");
                // StartCoroutine(loadingScript.restartLoad());
                // StartCoroutine(RespawnAfterDelay(respawnPoint, 1f)); 
                // deadText.SetActive(false);
                // playerHealth.returnDead(); 

            }
    }

}
