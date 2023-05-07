using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using TMPro;
using System.Collections;
using System.Linq;


public class button1 : MonoBehaviour
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
    public GameObject jumpPad;
    public GameObject jumpPad1;
    public GameObject jumpPad2;
    public Material jumpPadOn;
    public Material jumpPadOff;

    public PlayerGalaw playerGalaw;

    private void Start()
    {
        buttons = GameObject.FindGameObjectsWithTag("Button1");
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
                Debug.Log("HIT");
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
                        for (int j = 0; j < clickedButtons.Count; j++) {
                            int buttonValue = clickedButtons[j];
                            switch (buttonValue) {
                                case 0:
                                    jumpPad.GetComponent<Renderer>().material = jumpPadOn;
                                    
                                    break;
                                case 2:
                                    jumpPad1.GetComponent<Renderer>().material = jumpPadOn;
                                    break;
                                case 4:
                                    jumpPad2.GetComponent<Renderer>().material = jumpPadOn;
                                    break;
                                default:
                                    break;
                            }
                        }


                        if (clickedButtons.Count == 4)
                        {
                            ResetButtonState();
                        }
                        else if (clickedButtons.Count == 3)
                        {
                            clickedButtons.Sort();
                            if (Enumerable.SequenceEqual(clickedButtons, new List<int> {0, 2, 4})) {
                                Debug.Log("you win");
                                StartCoroutine(levelPassed());
                                jumpPad.GetComponent<Renderer>().material = jumpPadOn;
                                jumpPad1.GetComponent<Renderer>().material = jumpPadOn;
                                jumpPad2.GetComponent<Renderer>().material = jumpPadOn;
                                playerGalaw.jumpPadForce = 10f;
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
        jumpPad.GetComponent<Renderer>().material = jumpPadOff;
        jumpPad1.GetComponent<Renderer>().material = jumpPadOff;
        jumpPad2.GetComponent<Renderer>().material = jumpPadOff;
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
