using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Video;
using UnityEngine.InputSystem;


public class loadingVideo : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject playerHud;
    [SerializeField] private Slider loadingSlider;
    public VideoClip[] videoClips;
    public GameObject transition;
    public GameObject loadingOff;
    public GameObject transitionSfx;
    public string levelToLoad;
    public string levelToReload;

    public VideoPlayer videoPlayer;

    public void Start()
    {
        transition.SetActive(false);
        transitionSfx.SetActive(false);
        // loadingScreen.SetActive(true);
        // StartCoroutine(loadLevel());

        PlayRandomVideoClip();
    }
    void OnTriggerEnter(Collider other)
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
        
        yield return new WaitForSeconds(5f);
        transitionSfx.SetActive(true);
        transition.SetActive(true);
        yield return new WaitForSeconds(1.4f);





        // Load the new scene additively
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);

        while (!loadOperation.isDone)
        {

            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);

            loadingSlider.value = progressValue;
            if (progressValue > 01f)
            {
                yield return new WaitForSeconds(1.5f);
                Debug.Log("switching");
            }
            yield return null;
        }

    }


    public void PlayRandomVideoClip()
    {
        int randomIndex = Random.Range(0, videoClips.Length);
        videoPlayer.clip = videoClips[randomIndex];
        videoPlayer.Play();
    }
    public IEnumerator LoadLevelASync()
    {



        Debug.Log("LEVEL NEXT");
        yield return new WaitForSeconds(Random.Range(5f, 10f));



    }

    public void buttonNextLvL()
    {
        StartCoroutine("LoadNextScene");
    }
    public IEnumerator loadLevel()
    {

        loadingOff.SetActive(true);

        loadingScreen.SetActive(true);

        yield return new WaitForSeconds(2f);



        // Load the new scene additively
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelToReload, LoadSceneMode.Additive);

        // Wait for the new scene to finish loading
        while (!asyncLoad.isDone)
        {
            transitionSfx.SetActive(true);
            transition.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            // Unload the previous scene
            AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            yield return new WaitUntil(() => asyncUnload.isDone);
            yield return null;

        }
    }
}
