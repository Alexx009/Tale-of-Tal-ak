using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleSpawn : MonoBehaviour
{
    public GameObject tentacle;
    private PlayerGalaw playerGalawScript;
    public Animator animators;

    public GameObject hud1;
    public GameObject hud2;    
    public GameObject hud3;
    public MouseLook camera;
    public GameObject inviWall;
    public Animator finalcamanimator;
    public Camera mainCamera;
    public Follower follower;

    // Start is called before the first frame update
    void Start()
    {
        
        playerGalawScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGalaw>();
        camera = camera.GetComponent<MouseLook>();
        //finalcamera.enabled = false;
        finalcamanimator.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            //follower.enabled = false;
            finalcamanimator.enabled = true;
            mainCamera.enabled = false;
            tentacle.SetActive(true);
            animators.Play("Armature|1_Idle_1");
            camera.enabled = false;
            mainCamera.enabled = false;
            //finalcamera.enabled = true;
            Debug.Log("nakatapak naman. ma bat ayaw gumana?!!!!");
            StartCoroutine(BriefStopCharac());
        }
    }
    
    private IEnumerator BriefStopCharac(){
       
        finalcamanimator.SetBool("Trigger", true);
        hud1.SetActive(false);
        hud2.SetActive(false);
        hud3.SetActive(false);
       animators.enabled = false;
        inviWall.SetActive(false);
        playerGalawScript.enabled = false;
        yield return new WaitForSeconds(6.4f);
        //finalcamera.enabled = false;
        mainCamera.enabled = true;
        playerGalawScript.enabled = true;
        animators.enabled = true;
    }
}
