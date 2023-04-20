using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
 private Animator elevatorAnim;
    void Start()
    {
        elevatorAnim = GameObject.Find("Elevator").GetComponent<Animator>();
    }

   private void OnTriggerStay(Collider other) {
    if(other.CompareTag("Player")){
     StartCoroutine(ElevatorUp());
    }
   }
   IEnumerator ElevatorUp(){
    yield return new WaitForSeconds(1);
   elevatorAnim.Play("ElevatorUp");
   }
}
