using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateCloser : MonoBehaviour
{
  private Animator gateAnimator;
  public bool isDoorClose = false;
  private void Start() {
    gateAnimator = GameObject.Find("Gate").GetComponent<Animator>();
  }
private void OnTriggerEnter(Collider other) {
    if(other.CompareTag("Player") && !isDoorClose){
        gateAnimator.Play("Door_AnimClose");
        isDoorClose = true;
    }
}
}
