using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleSpawn : MonoBehaviour
{
    public GameObject tentacle;
    private PlayerGalaw playerGalawScript;
    public Animator animators;
    
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
          //  animators.enabled = false;
            StartCoroutine(BriefStopCharac());
        }
    }
    
    private IEnumerator BriefStopCharac(){
        playerGalawScript.enabled = false;
        yield return new WaitForSeconds(4);
        playerGalawScript.enabled = true;
        animators.enabled = true;
    }
}
