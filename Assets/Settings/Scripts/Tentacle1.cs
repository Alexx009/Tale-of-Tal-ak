using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle1 : MonoBehaviour
{
    public float bulletDamage;
    EnemyGameManager enemyGameManagerScript;
    
    void Start(){
        bulletDamage = Random.Range(4f, 10f);
        enemyGameManagerScript = GameObject.Find("EnemyGameManager").GetComponent<EnemyGameManager>();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Bullet")){
            enemyGameManagerScript.TentacleTakeDamage1(bulletDamage);
        }
    }
}
