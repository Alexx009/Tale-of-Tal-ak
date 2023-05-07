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

    public GameObject inviWall;
    
    // Start is called before the first frame update
    void Start()
    {
        playerGalawScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGalaw>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            tentacle.SetActive(true);
          
          
                 animators.Play("Armature|1_Idle_1");
                 
            StartCoroutine(BriefStopCharac());
        }
    }
    
    private IEnumerator BriefStopCharac(){
       hud1.SetActive(false);
           hud2.SetActive(false);
               hud3.SetActive(false);
       animators.enabled = false;
        inviWall.SetActive(false);
        playerGalawScript.enabled = false;
        yield return new WaitForSeconds(8);
        playerGalawScript.enabled = true;
        animators.enabled = true;
    }
}
