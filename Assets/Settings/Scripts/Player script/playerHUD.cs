using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHUD : MonoBehaviour
{
    public LeanTweenType inType;

    public RectTransform quest; // game object to move

    public RawImage questImage;
    public Texture newImageSprite;
    public Texture oldImageSprite;

    public GameObject questGameObject;



    private bool isAtInitialPosition = true; // flag to track the object's current position
    private void Start()
    {
        quest.LeanMoveX(800, 0.01f).setEase(inType);
        questGameObject.SetActive(false);
        Invoke("StartAnimationQuest", 6f);
    }

    void StartAnimationQuest()
    {
        questGameObject.SetActive(true);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {

            if (isAtInitialPosition)
            {
                StartCoroutine(QuestOpen());
            }
            if (!isAtInitialPosition)
            {
                StartCoroutine(QuestClose());
            }
        }

    }

    IEnumerator QuestOpen()
    {

        // move the object using LeanTween
        quest.LeanMoveX(0, 0.5f).setEase(inType);
        Debug.Log("moveing");

        // Change the sprite of the Image component to the new image
        questImage.texture = newImageSprite;


        yield return new WaitUntil(() => quest.anchoredPosition.x == 0);
        // update the flag
        Debug.Log("READY TO MOVE");
        isAtInitialPosition = false;
    }
    IEnumerator QuestClose()
    {
        // move the object back to the initial position
        quest.LeanMoveX(800, 0.5f).setEase(inType);

        // Change the sprite of the Image component back to the old image
        questImage.texture = oldImageSprite;

        yield return new WaitUntil(() => quest.anchoredPosition.x == 800);
        // update the flag
        Debug.Log("READY TO CLOSE");
        isAtInitialPosition = true;
    }
}

