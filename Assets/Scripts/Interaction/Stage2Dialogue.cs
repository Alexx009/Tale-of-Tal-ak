using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Dialogue : MonoBehaviour
{
    public DialogueScripStage2 dialogueScripStage2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tricky"))
        {
            dialogueScripStage2.Tricky();
             Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Success"))
        {
            dialogueScripStage2.Finish();
            Destroy(other.gameObject);
        }
    }
}
