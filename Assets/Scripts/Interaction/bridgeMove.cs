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
    public GameObject objectToRotate;

    public Material buttonOn;
    public Material buttonOff;

    public float rotateOnValue;
    public float rotateOffValue;
    public float rotationTime;
    public LeanTweenType rotationEaseType;

    private bool buttonState = false;
    public string objectId;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            Vector3 centerScreen = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
            Ray ray = mainCamera.ScreenPointToRay(centerScreen);

            if (Physics.Raycast(ray, out hit, rayLength, layerMask))
            {
                if (hit.transform.gameObject == button && hit.transform.gameObject.name == objectId)
                {
                    buttonState = !buttonState;

                    button.GetComponent<Renderer>().material = buttonState ? buttonOn : buttonOff;

                    if (buttonState)
                    {
                        Debug.Log("true");
                        LeanTween.rotateY(objectToRotate, rotateOnValue, rotationTime).setEase(rotationEaseType);
                    }
                    else
                    {
                        Debug.Log("False");
                        LeanTween.rotateY(objectToRotate, rotateOffValue, rotationTime).setEase(rotationEaseType);
                    }
                }
            }
        }
    }
}
