
using UnityEngine;

public class Target : MonoBehaviour
{
   public float health = 50f;
   public ParticleSystem hitEffect;
   public void TakeDamage(float amount){
    health -= amount;
    if(health<= 0f){
        Die();
    }

   }
   void Die(){
    Destroy(gameObject);
   }

   private void OnCollisionEnter(Collision other) {
    if(other.gameObject.CompareTag("Bullet")){
        Instantiate(hitEffect, other.gameObject.GetComponent<Transform>().position,other.transform.rotation);
        TakeDamage(10f);
    }
   }
}
