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
        loadingScreen.SetActive(false);
        PlayRandomVideoClip();
    }
    public void Update() {
        if(Input.GetKeyDown(KeyCode.O)){
            StartCoroutine(LoadLevelASync(levelToLoad));
        }
    }

    public void PlayRandomVideoClip()
    {
        int randomIndex = Random.Range(0, videoClips.Length);
        videoPlayer.clip = videoClips[randomIndex];
        videoPlayer.Play();
    }
IEnumerator LoadLevelASync(string levelToLoad){
    playerHud.SetActive(false);
    videoPlayer.enabled = true;
    loadingScreen.SetActive(true);
    
    yield return new WaitForSeconds(Random.Range(5f,10f));
    SceneManager.LoadSceneAsync(levelToLoad);
    
}

}
