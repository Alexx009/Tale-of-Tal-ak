using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReloader : MonoBehaviour
{
    PlayerGalaw playerGalaw;
    MouseLook cameraGalaws;
    [SerializeField] GameObject FPSplayer;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject doorCam;
    [SerializeField] GameObject mainCam;
    [SerializeField] GameObject crossHair;
    public float defaultHP;
    void Awake()
    {
        playerGalaw = FPSplayer.GetComponent<PlayerGalaw>();
        cameraGalaws = mainCam.GetComponent<MouseLook>();
    }
    void Start()
    {
       
        StartCoroutine(Kurotins());
        playerGalaw.enabled = false;
        gameOver.SetActive(false);
        doorCam.SetActive(true);
        cameraGalaws.enabled = false;
        mainCam.SetActive(false);
        crossHair.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        defaultHP = playerGalaw.defaultHP;
        if (defaultHP <= 0)
        {
            gameOver.SetActive(true);
            StartCoroutine(Coroutins());
            
           
        }
    }
    IEnumerator Coroutins()
    {
   
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    IEnumerator Kurotins()
    {
        yield return new WaitForSeconds(5f);

        playerGalaw.enabled = true;
        cameraGalaws.enabled = true;
        mainCam.SetActive(true);
        doorCam.SetActive(false);
        crossHair.SetActive(true);
    }
}
