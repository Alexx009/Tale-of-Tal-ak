using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EnemyGameManager : MonoBehaviour
{
 public Image healthBar;
 public Image tentacleHealthBar1;
  public Image tentacleHealthBar2;
   public Image tentacleHealthBar3;


 public bool isVulnerable = true;
 
 public float tentacleCurrentHealth1, tentacleCurrentHealth2, tentacleCurrentHealth3 = 100f;
 public float tentacleMaxHealth1, tentacleMaxHealth2, tentacleMaxHealth3 = 100f;

 public float enemyMaxHealth = 100f;
 public float enemyCurrentHealth = 100f;

public GameObject tentacles;
public GameObject mainBoss;
public GameObject mainBossHealthGO;

private OctoFoodScript octoFoodScript;

private EnemyGameManager enemyGameManagerScript;

public TextMeshProUGUI questComplete;
public TextMeshProUGUI changeDialogue;


[SerializeField]private GameObject questText;

void Start(){
    octoFoodScript = GameObject.FindGameObjectWithTag("Player").GetComponent<OctoFoodScript>();
     enemyGameManagerScript = GetComponent<EnemyGameManager>();
     questComplete = GameObject.Find("QuestTextUI").GetComponent<TextMeshProUGUI>();
   changeDialogue= GameObject.Find("DiaText").GetComponent<TextMeshProUGUI>();
  
    enemyCurrentHealth = enemyMaxHealth;
}
    // Update is called once per frame
    void Update()
    {
         if(enemyCurrentHealth <= 0){
        
            changeDialogue.text = "Donny: Thank you so much! Here's $999999999";
            questComplete.text = "Quest: Kill the Kraken (Completed)";
            questText.SetActive(true);
        Destroy(mainBossHealthGO, 0);
        Destroy(mainBoss, 0);
        Destroy(tentacles, 0);
        Destroy(octoFoodScript.indicator,0);
        enemyCurrentHealth = 0f;
        healthBar.fillAmount = 0;
            octoFoodScript.enabled = false;
            enemyGameManagerScript.enabled = false;

        //play deathanimation
    
        
     

  }
  
   if(enemyCurrentHealth <= enemyMaxHealth * 0.7f){
               isVulnerable = false;
               tentacles.SetActive(true);
               healthBar.color = Color.blue;

        }
          if(tentacleCurrentHealth1 <= 0f && tentacleCurrentHealth2 <=0 && tentacleCurrentHealth3 <= 0f)
        {
            
            ResumeBossMainHealth();
         //   Destroy(tentacles, 0f);
        }
   
    }
    public void EnemyTakeDamage(float amount){
        enemyCurrentHealth -= amount;
        healthBar.fillAmount = enemyCurrentHealth/enemyMaxHealth;

    }

    public void TentacleTakeDamage1(float amount){
        tentacleCurrentHealth1 -= amount;
        tentacleHealthBar1.fillAmount = tentacleCurrentHealth1/tentacleMaxHealth1;

    }

    public void TentacleTakeDamage2(float amount){
        tentacleCurrentHealth2 -= amount;
        tentacleHealthBar2.fillAmount = tentacleCurrentHealth2/tentacleMaxHealth2;


    }
    public void TentacleTakeDamage3(float amount){
        tentacleCurrentHealth3 -= amount;
        tentacleHealthBar3.fillAmount = tentacleCurrentHealth3/tentacleMaxHealth3;


    }

    public void ResumeBossMainHealth(){
      
             healthBar.color = Color.red;
            isVulnerable = true;
        
    }
   


}
