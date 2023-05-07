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
    public Animator questAnimators;
    public int animPar;

    public GameObject playerhud;
    playerHUD playerhudd;   
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
        questAnimators = questAnimators.GetComponent<Animator>();
        animPar = questAnimators.GetInteger("Clicker");
        playerhudd = playerhud.GetComponent<playerHUD>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && animPar == 0)
        {
            Debug.Log("Pressed tab key");

            questImage.texture = newImageSprite;
            
            questAnimators.SetInteger("Clicker", 1);
            StartCoroutine(Queston());
           
        }
        if (Input.GetKeyDown(KeyCode.Tab) && animPar == 1)
        {


            questAnimators.SetInteger("Clicker", 2);
            StartCoroutine(Questoff());

        }
      
    }     

    IEnumerator Queston()
    {
        playerhudd.enabled = false;
        yield return new WaitForSeconds(1f);
        playerhudd.enabled = true;
        animPar = 1;
    }
    IEnumerator Questoff()
    {
        playerhudd.enabled = false;
        yield return new WaitForSeconds(1f);
        playerhudd.enabled = true;
        animPar = 0;
        questImage.texture = oldImageSprite;
        questAnimators.SetInteger("Clicker", 0);
    }
  
}

