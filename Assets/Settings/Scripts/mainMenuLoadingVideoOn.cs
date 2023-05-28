using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuLoadingVideoOn : MonoBehaviour
{
    public GameObject loadingVideo;
    public mainMenuElementAnimation mainMenuElementAnimation;
    // Start is called before the first frame update
    void Awake()
    {
        loadingVideo.SetActive(true);
        mainMenuElementAnimation.enabled = false;
        
    }


    private void Start()
    {
        Invoke("TurnOffTheVideo", 3f);
    }


    void TurnOffTheVideo()
    {
        mainMenuElementAnimation.enabled = true;
        loadingVideo.SetActive(false);
    }
}
