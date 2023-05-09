using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Video;


public class loadingVideo : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject playerHud;
    [SerializeField] private Slider loadingSlider;
    public VideoClip[] videoClips;

    public string levelToLoad;

    public VideoPlayer videoPlayer;

    public void Start()
    {
        loadingScreen.SetActive(true);
        StartCoroutine(loadLevel());
        
        PlayRandomVideoClip();
    }
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerHud.SetActive(false);
            videoPlayer.enabled = true;
            loadingScreen.SetActive(true);
            StartCoroutine(LoadLevelASync());
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);
    
        }
    }

    public void PlayRandomVideoClip()
    {
        int randomIndex = Random.Range(0, videoClips.Length);
        videoPlayer.clip = videoClips[randomIndex];
        videoPlayer.Play();
    }
public IEnumerator LoadLevelASync(){


    
    Debug.Log("LEVEL NEXT");   
    yield return new WaitForSeconds(Random.Range(5f,10f));
     
     
    
}
public IEnumerator loadLevel(){
   
    Debug.Log("LEVEL load");   
    yield return new WaitForSeconds(5f);  
    loadingScreen.SetActive(false);
}
}
