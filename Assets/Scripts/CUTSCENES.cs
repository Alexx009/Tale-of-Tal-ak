using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CUTSCENES : MonoBehaviour
{
    public double time;
    public double currentTime;
    public double endFrame;
    public string sceneToLoad;
    // Use this for initialization
    void Start()
    {

        time = gameObject.GetComponent<VideoPlayer>().clip.length;
    }


    // Update is called once per frame
    void Update()
    {
        currentTime = gameObject.GetComponent<VideoPlayer>().time;
        if (currentTime >= endFrame)
        {
            Debug.Log("end video");
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}