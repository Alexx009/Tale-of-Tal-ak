using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDamage : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Enemy") {
            Debug.Log("hitting");
            enemyHealth enemy = collision.gameObject.GetComponent<enemyHealth>();
            if (enemy != null) {
                enemy.TakeDamage(10);
            }
        }
    }
}
