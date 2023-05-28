using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class playerFall : MonoBehaviour
{

    private Vector3 respawnPoint;
    public loadingVideo transition;
    public GameObject transitionObject;

    [SerializeField] private Settings_Script pause;
    [SerializeField] private GameObject playerHud;
    public playerHealth playerHealth;
    public GameObject deadText;
    public DialogueScripStage2 dialogueScripStage2;
    private bool once = false;

    public string sceneToReLoad;

    private void Start()
    {
        StartCoroutine(waitings());
    }

    IEnumerator waitings()
    {
        yield return new WaitForSeconds(2f);
        transitionObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("lava"))
        {

            if (!once)
            {
                dialogueScripStage2.Dead();
                once = true;
            }

            playerDead();

        }
    }

    public void playerDead()
    {


        deadText.SetActive(true);
        Debug.Log("dead");
        playerHud.SetActive(false);
        pause.Pause();
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(sceneToReLoad);
        }
    }

}
