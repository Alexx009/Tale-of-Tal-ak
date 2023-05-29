using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Random = UnityEngine.Random;

public class mainMenuElementAnimation : MonoBehaviour
{
    public LeanTweenType inType;
    public LeanTweenType outType;
    public GameObject buttonsPanel;
    public GameObject[] buttons;
    public GameObject titlePanel;
    public RectTransform settingsPanelRect;
    public RectTransform stagePanelRect;

    public void Start()
    {

        Cursor.lockState = CursorLockMode.None;
        RectTransform[] buttonsPanelChild = new RectTransform[buttons.Length];

        RectTransform buttonsPanelRect = buttonsPanel.GetComponent<RectTransform>();
        buttonsPanelRect.SetLocalPositionAndRotation(new Vector3(0, 500, 0), new Quaternion(0, 0, 0, 0));
        buttonsPanel.LeanMoveY(0, 0.5f).setEaseLinear().setDelay(1);

        RectTransform titlePanelRect = titlePanel.GetComponent<RectTransform>();
        titlePanelRect.localPosition = new Vector3(-16900, 0, 0);
        titlePanelRect.LeanMoveX(1000, 1).setEase(inType).setDelay(1);

        settingsPanelRect.LeanSetPosX(220);
        stagePanelRect.LeanSetPosX(220);


        int space = -200; // Set the spacing between buttons


        for (int i = 0; i < buttons.Length; i++)
        {
            int resSpace = i * space; // Calculate the position of the current button
            buttonsPanelChild[i] = buttons[i].GetComponent<RectTransform>();
            buttonsPanelChild[i].LeanMoveY(-400 + resSpace, .5f).setEase(LeanTweenType.easeOutQuart)
            .setSpeed(600).setDelay(1.5f);
        }
        Vector2 randomValues = randomNumber();
        Vector2 randomValues1 = randomNumber();
        Vector2 randomValues2 = randomNumber();

        buttonsPanelChild[0].LeanMoveX(randomValues.x, randomValues.y).setEase(LeanTweenType.linear).setLoopPingPong(2).setDelay(2).setRepeat(200);
        buttonsPanelChild[1].LeanMoveX(randomValues1.x, randomValues1.y).setEase(LeanTweenType.linear).setLoopPingPong(2).setDelay(2).setRepeat(200);
        buttonsPanelChild[2].LeanMoveX(randomValues2.x, randomValues2.y).setEase(LeanTweenType.linear).setLoopPingPong(2).setDelay(2).setRepeat(200);

        Debug.Log(randomValues);
        Debug.Log(randomValues1);
        Debug.Log(randomValues2);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            RefreshScene();
        }
    }

    Vector2 randomNumber()
    {
        float distance = UnityEngine.Random.Range(300f, 340f);
        float speed = UnityEngine.Random.Range(1f, 1.5f);
        return new Vector2(distance, speed);
    }

    public void RefreshScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex, LoadSceneMode.Single);
    }

    public void settings()
    {
        settingsPanelRect.LeanMoveX(1300, 1).setEase(inType);
        stagePanelRect.LeanMoveX(3000, 1).setEase(inType);
    }
    public void settingsClose()
    {
        settingsPanelRect.LeanMoveX(3000, 1).setEase(inType);
    }
    public void stages()
    {
        stagePanelRect.LeanMoveX(1300, 1).setEase(inType);
        settingsPanelRect.LeanMoveX(3000, 1).setEase(inType);

    }
    public void stagesClose()
    {
        stagePanelRect.LeanMoveX(3000, 1).setEase(inType);
    }

    private void Update() {
        Cursor.visible = true;
    }

    public void Play()
    {

    }

}
