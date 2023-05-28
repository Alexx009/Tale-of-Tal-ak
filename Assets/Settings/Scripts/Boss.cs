using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public EnemyGameManager enemyGameManagerScript;
    private float bulletDamage;
    // Start is called before the first frame update
    void Start()
    {
        bulletDamage = Random.Range(4f,10f);
        enemyGameManagerScript = GameObject.Find("EnemyGameManager").GetComponent<EnemyGameManager>();
    }

    public void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Bullet") && enemyGameManagerScript.isVulnerable){
            enemyGameManagerScript.EnemyTakeDamage(bulletDamage);
        }
        
    }
}
