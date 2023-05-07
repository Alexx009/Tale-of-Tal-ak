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
    public GameObject transition;

    public GameObject deadText;


    private void Start() {
        transition.SetActive(false);
        loadingScreen.SetActive(false);
        deadText.SetActive(false);
    }
    public IEnumerator restartLoad(){
        loadingScreen.SetActive(true);
        transition.SetActive(true);
        deadText.SetActive(false);
        yield return new WaitForSeconds(1.2f);
        loadingScreen.SetActive(false);
        pause.ResumeGame();
        Debug.Log("loading");
        yield return new WaitForSeconds(2.4f);
        
        transition.SetActive(false);
        
        
        

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
