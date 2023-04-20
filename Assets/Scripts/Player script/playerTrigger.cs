using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerTrigger : MonoBehaviour
{    
    private bool isOnce = true;
    [SerializeField] private TextMeshProUGUI centerText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("octofood") && isOnce)
        {

            ShowMessage("OCTOFOOD");
            isOnce = false;
        }
    }

    private void ShowMessage(string message)
    {
        centerText.text = message;
        centerText.gameObject.SetActive(true);
        StartCoroutine(HideMessage());
    }    
    
    private IEnumerator HideMessage()
    {
        yield return new WaitForSeconds(3f);
        centerText.gameObject.SetActive(false);
    }
}