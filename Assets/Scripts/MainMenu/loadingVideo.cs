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
    public GameObject transition;
    public GameObject loadingOff;
    public string levelToLoad;
    public string levelToReload;

    public VideoPlayer videoPlayer;

    public void Start()
    {
        transition.SetActive(false); 
        // loadingScreen.SetActive(true);
        // StartCoroutine(loadLevel());
        
        PlayRandomVideoClip();
    }
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerHud.SetActive(false);
            StartCoroutine(LoadNextScene());
            // AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);
    
        }
    }
public IEnumerator LoadNextScene()
{


    loadingOff.SetActive(true);

    loadingScreen.SetActive(true);


    // Wait for the player to press Enter before switching to the next scene
    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
    
    yield return new WaitForSeconds(2f); 

    
    
    // Load the new scene additively
    AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelToLoad, LoadSceneMode.Additive);

    // Wait for the new scene to finish loading
    while (!asyncLoad.isDone) {
        transition.SetActive(true);
        yield return new WaitForSeconds(1.5f); 
        // Unload the previous scene
        AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        yield return new WaitUntil(() => asyncUnload.isDone);
        yield return null;

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

public void buttonNextLvL(){
    StartCoroutine("LoadNextScene");
}
public IEnumerator loadLevel(){
   
    loadingOff.SetActive(true);

    loadingScreen.SetActive(true);
    
    yield return new WaitForSeconds(2f); 

    
    
    // Load the new scene additively
    AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelToReload, LoadSceneMode.Additive);

    // Wait for the new scene to finish loading
    while (!asyncLoad.isDone) {
        transition.SetActive(true);
        yield return new WaitForSeconds(1.5f); 
        // Unload the previous scene
        AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        yield return new WaitUntil(() => asyncUnload.isDone);
        yield return null;

    }
}
}
