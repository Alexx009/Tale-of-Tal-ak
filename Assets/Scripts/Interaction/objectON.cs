using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectON : MonoBehaviour
{
    public Animator buttonAnim;

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("barrel")){
            buttonAnim.SetBool("isPushed", true);
        }
    }

    private void OnCollisionExit(Collision other) {
        if(other.gameObject.CompareTag("barrel")){
            buttonAnim.SetBool("isPushed", false);
        }
    }    
}
