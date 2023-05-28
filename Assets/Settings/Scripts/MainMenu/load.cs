using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class load : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject mainMenu;
    
    [SerializeField] private Slider loadingSlider;
    [SerializeField] private Settings_Script pause;
    [SerializeField] private TextMeshProUGUI dead;
    [SerializeField] private TextMeshProUGUI pressR;
    [SerializeField] private GameObject transition;



    private void Start() {
        transition.SetActive(false);
    }

    public IEnumerator restartLoad(){
        pause.ResumeGame();
        dead.enabled = false;
        pressR.enabled = false;
        loadingScreen.SetActive(true);
        
        yield return new WaitForSeconds(1.2f);
        loadingScreen.SetActive(value: false);
        transition.SetActive(true);
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