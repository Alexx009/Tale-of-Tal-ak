using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHUD : MonoBehaviour
{
    public float QuestmoveDistance = 1f; // distance to move in the x-axis
    public float moveTime = 1f; // time to complete the movement
    public float alphaValue = 0.5f; // fixed alpha value to set
    public float alphaValueNormal = 1f; // fixed alpha value to set

    public GameObject quest; // game object to move
    public GameObject barefin; // game object to move
    public GameObject squirter; // game object to move
    private Vector3 questInitialPosition; // initial position of the object
    private Vector3 barefinInitialPosition; // initial position of the object
    private Vector3 squirterInitialPosition; // initial position of the object
    
    public RawImage questImage;
    public Texture newImageSprite;
    public Texture oldImageSprite;

    

    private bool isAtInitialPosition = true; // flag to track the object's current position



    void Start()
    
    {
        // store the initial position of the object
        questInitialPosition = quest.transform.localPosition;
        barefinInitialPosition = barefin.transform.localPosition;
        squirterInitialPosition = squirter.transform.localPosition;
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("Pressed tab key");

            if (isAtInitialPosition) {
                // calculate the target position based on local transform
                Vector3 targetPosition = quest.transform.localPosition + new Vector3(QuestmoveDistance, 0, 0);

                // move the object using LeanTween
                quest.LeanMoveLocal(targetPosition, moveTime).setEase(LeanTweenType.linear);

                // Change the sprite of the Image component to the new image
                questImage.texture = newImageSprite;

                // update the flag
                isAtInitialPosition = false;
            } else {
                // move the object back to the initial position
                quest.LeanMoveLocal(questInitialPosition, moveTime).setEase(LeanTweenType.linear);

                // Change the sprite of the Image component back to the old image
                questImage.texture = oldImageSprite;

                // update the flag
                isAtInitialPosition = true;
            }
        }



        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Pressed Q key");

            if (isAtInitialPosition) {
                // calculate the target positions based on initial positions
                Vector3 targetPosition1 = barefinInitialPosition + new Vector3(522f, 0, 0);
                Vector3 targetPosition2 = squirterInitialPosition + new Vector3(-522f, 0, 0);


                // move the objects using LeanTween
                barefin.LeanMoveLocal(targetPosition1, moveTime).setEase(LeanTweenType.linear);
                squirter.LeanMoveLocal(targetPosition2, moveTime).setEase(LeanTweenType.linear);

                // update the flag
                isAtInitialPosition = false;
            } else {

                // move the objects back to the initial positions
                barefin.LeanMoveLocal(barefinInitialPosition, moveTime).setEase(LeanTweenType.linear);
                squirter.LeanMoveLocal(squirterInitialPosition, moveTime).setEase(LeanTweenType.linear);

                // update the flag
                isAtInitialPosition = true;
                
            }
        }

    }
}

