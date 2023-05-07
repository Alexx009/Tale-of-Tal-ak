using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGameManager : MonoBehaviour
{
    public float playerMaxHealth = 100f;
 public float playerCurrentHealth = 100f;
 public float bulletDamage = 30f;

 public AudioClip audioClip;
 public AudioSource audio1;
 public AudioSource audio2;
 public bool isAudioPlayed1 = true ;
 public bool isAudioPlayed2 = true ;

 public int audioNumberer = 0;

 public Image playerHealthBar;
    // Start is called before the first frame update
    void Start()
    {
        
        audio1 = GameObject.Find("octofooddialogue1").GetComponent<AudioSource>();
         audio2 = GameObject.Find("octofooddialogue2").GetComponent<AudioSource>();
     
        playerCurrentHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(playerCurrentHealth <=0f){

        }
    }
    public void PlayerTakeDamage(float amount){
     playerCurrentHealth -= amount;
     playerHealthBar.fillAmount = playerCurrentHealth/playerMaxHealth;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Bullet")){
            Debug.Log("Hit");
PlayerTakeDamage(100f);
        }

    }
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("octofooddialogue1")  && audioNumberer == 0){
        audio1.Play();
        audioNumberer = 1;
      //  StartCoroutine("Wait");
//isAudioPlayed1 = false;
    

        }
        if(other.CompareTag("octofooddialogue2")  && audioNumberer == 1){
        audio2.Play();
           audioNumberer = 2;
        //   StartCoroutine("Wait");
        // isAudioPlayed2 = false;
       

        }
    }
    
    private IEnumerator Wait1(){
        yield return new WaitForSeconds(1);
                isAudioPlayed1 = false;
                isAudioPlayed2 = false;
    }
}
