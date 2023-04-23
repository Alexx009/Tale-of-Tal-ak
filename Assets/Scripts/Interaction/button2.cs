using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using TMPro;
using System.Collections;

public class button2 : MonoBehaviour
{
    public Camera mainCamera;
    public TextMeshProUGUI text;
    public float rayLength;
    public LayerMask layerMask;
    public Material newMaterial;

    public GameObject[] buttons;
    private Material[] originalMaterials;
    private float buttonZaxis;
    private bool levelComplete = false;

    private void Start()
    {
        buttons = GameObject.FindGameObjectsWithTag("Button2");
        originalMaterials = new Material[buttons.Length];
        buttonZaxis = buttons[0].transform.localPosition.z;
        text.SetText("Level Passed!");
        text.enabled = false;

        for (int i = 0; i < buttons.Length; i++)
        {
            Renderer renderer = buttons[i].GetComponent<Renderer>();
            originalMaterials[i] = renderer.material;
        }
    }

private List<int> clickedButtons = new List<int>();

    private void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            Vector3 centerScreen = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
            Ray ray = mainCamera.ScreenPointToRay(centerScreen);

            if (Physics.Raycast(ray, out hit, rayLength, layerMask))
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    if (hit.collider.gameObject == buttons[i] && !levelComplete)
                    {
                        float targetZ = buttons[i].transform.localPosition.z == buttonZaxis ? 0.2f : buttonZaxis;
                        LeanTween.moveLocalZ(buttons[i], targetZ, 0.5f).setEase(LeanTweenType.easeOutQuad);

                        Renderer renderer = buttons[i].GetComponent<Renderer>();
                        Material currentMaterial = renderer.material;
                        Material newButtonMaterial = currentMaterial.name == originalMaterials[i].name ? newMaterial : originalMaterials[i];
                        renderer.material = newButtonMaterial;

                        clickedButtons.Add(i);
                        if (clickedButtons.Count == 4)
                        {
                            ResetButtonState();
                        }
                        else if (clickedButtons.Count == 3)
                        {
                            if (clickedButtons[0] == 2 && clickedButtons[1] == 5 && clickedButtons[2] == 3)
                            {
                                Debug.Log("you win");
                                StartCoroutine(levelPassed());
                                
                            }
                            else
                            {
                                StartCoroutine(ResetButtonState());
                            }
                        }
                    }
                }
            }
        }
    }
    IEnumerator levelPassed(){
        text.enabled = true;
        
        yield return new WaitForSeconds(2);

        text.enabled = false;
        levelComplete = true;

    }

    IEnumerator ResetButtonState()
    {
        clickedButtons.Clear();
        yield return new WaitForSeconds(2);
        foreach (GameObject button in buttons)
        {
            float targetZ = button.transform.localPosition.z == buttonZaxis ? 0.2f : buttonZaxis;
            LeanTween.moveLocalZ(button, targetZ, 0.5f).setEase(LeanTweenType.easeOutQuad);

            Renderer renderer = button.GetComponent<Renderer>();
            renderer.material = originalMaterials[System.Array.IndexOf(buttons, button)];
        }
    }
}
