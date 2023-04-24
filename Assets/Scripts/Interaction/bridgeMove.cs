using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class bridgeMove : MonoBehaviour
{
    public Camera mainCamera;
    public float rayLength;
    public LayerMask layerMask;
    public GameObject button;
    public GameObject tulay;

    public Material buttonOn;
    public Material buttonOff;

    private bool buttonState = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit1;
            Vector3 centerScreen = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
            Ray ray1 = mainCamera.ScreenPointToRay(centerScreen);

            if (Physics.Raycast(ray1, out hit1, rayLength, layerMask))
            {
                // Toggle the button state
                buttonState = !buttonState;

                // Set the button material based on the current state
                button.GetComponent<Renderer>().material = buttonState ? buttonOn : buttonOff;

                if(buttonState){
                    Debug.Log("true");
                    LeanTween.rotateY(tulay, 49f, 1f).setEase(LeanTweenType.linear);
                }
                else{
                    Debug.Log("False");
                    LeanTween.rotateY(tulay, -36f, 1f).setEase(LeanTweenType.linear);
                }
            }
        }
    }
}

