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
    [SerializeField] private TextMeshProUGUI dead;
    [SerializeField] private TextMeshProUGUI pressR;


    private void Start() {

    }
    public IEnumerator restartLoad(){
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(2f);
        loadingScreen.SetActive(value: false);
        dead.enabled = false;
        pressR.enabled = false;
        pause.ResumeGame();

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