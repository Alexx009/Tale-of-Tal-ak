using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class loadingScript : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject mainMenu;
    
    [SerializeField] private Slider loadingSlider;
    [SerializeField] private Settings_Script pause;
    [SerializeField] private GameObject transition;
    [SerializeField] private GameObject deadText;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip transitionSfx;
    



    private void Start() {
        transition.SetActive(false);
    }
    public IEnumerator restartLoad(){
        pause.ResumeGame();
        deadText.SetActive(false);
        loadingScreen.SetActive(true);
        transition.SetActive(true);
        audioSource.PlayOneShot(transitionSfx);
        yield return new WaitForSeconds(1.2f);
        loadingScreen.SetActive(value: false);
        yield return new WaitForSeconds(2.2f);
        transition.SetActive(false);
        Debug.Log("loading");
        

    }
    public void loadLevelBtn(string levelToLoad) {
        mainMenu.SetActive(false);
        loadingScreen.SetActive(true);
        StartCoroutine(LoadLevelASync(levelToLoad));
    }

    IEnumerator LoadLevelASync(string levelToLoad){
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);

        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            loadingSlider.value = progressValue;
            yield return null;
        }
    }

    
}