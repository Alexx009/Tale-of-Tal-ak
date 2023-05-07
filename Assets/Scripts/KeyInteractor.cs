using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class KeyInteractor : MonoBehaviour
{
    public Transform cam;
    bool active = false;
<<<<<<< Updated upstream
    bool actives = false;
   
=======
    bool activesa = false;
    bool activesb = false;
    bool activesc = false;

>>>>>>> Stashed changes
    [SerializeField] PlayerGalaw playerGalawan;
    [SerializeField] GameObject palawOne;
    [SerializeField] GameObject palawTwo;
    [SerializeField] GameObject teleporter;
    [SerializeField] GameObject key;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject outerKey;
    [SerializeField] GameObject thirdKey;
    [SerializeField] GameObject secondwallpointer;
    [SerializeField] LayerMask pangkeylang;
    [SerializeField] LayerMask pangPader;
    [SerializeField] LayerMask pangPalaw;
    [SerializeField] GameObject firstWall;
    [SerializeField] GameObject secondWall;
    [SerializeField] GameObject thirdWall;
    [SerializeField] Animator wallAnimator;
    [SerializeField] GameObject thirdWallPointer;
    [SerializeField] GameObject pressE;
    [SerializeField] GameObject questTitle;
    bool questbool = false;
    public Animator questTitleAnimator;
    public Animator questContent;
    public int acquiredKey = 0;
    public TMP_Text questText;
    public TMP_Text lvlComplete;



    void Start()
    {
        playerGalawan = playerGalawan.GetComponent<PlayerGalaw>();
        pressE.SetActive(false);
        firstWall.SetActive(true);
        wallAnimator = wallAnimator.GetComponent<Animator>();
        questTitleAnimator = questTitle.GetComponent<Animator>();
        questContent = questContent.GetComponent<Animator>();
        StartCoroutine(QuestTitleCoro());
        questContent.SetBool("Open", false);

    }

    void Update()
    {
        //raycast
        active = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 5f, pangkeylang);
<<<<<<< Updated upstream
        actives = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out RaycastHit hitInfo, 5f, pangPader);
       
=======
        activesa = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out RaycastHit hitInfoa, 5f, wallOne);
        activesb = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out RaycastHit hitInfob, 5f, wallTwo);
        activesc = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out RaycastHit hitInfoc, 5f, wallThree);

>>>>>>> Stashed changes
        //raycast check
        if (active == true)
        {
            pressE.SetActive(true);
        }

        else
        {
            pressE.SetActive(false);
        }
        //Tab
        if (Input.GetKeyDown(KeyCode.Tab)&& questbool == false)
        {
            StartCoroutine(TabCoro());
        }
        if (Input.GetKeyDown(KeyCode.Tab) && questbool == true)
        {
            questContent.SetBool("Open", false);
            questbool = false;
        }


        //key interactor
        //1st key
        if (Input.GetKeyDown(KeyCode.E) && pressE.activeSelf)
        {
            Debug.Log("you are pressing E");
            key.SetActive(false);
            StartCoroutine(FirstKeyCoro());

        }
        //2nd key
        if (Input.GetKeyDown(KeyCode.E) && pressE.activeSelf)
        {
            if (acquiredKey == 1)
            {
                outerKey.SetActive(false);

                StartCoroutine(SecondWallCoroutine());
            }
        }
        //3rd key
        if (Input.GetKeyDown(KeyCode.E) && pressE.activeSelf)
        {
            if (acquiredKey == 2)
            {
                thirdKey.SetActive(false);

                StartCoroutine(ThirdWallCoroutine());
            }
        }
        //PalawOne
        if (Input.GetKeyDown(KeyCode.E) && pressE.activeSelf)
        {

            if (acquiredKey == 3)
            {
                lvlComplete.text = "Level 4: Complete";
                questText.text = "Finding Palaw\r\n\r\nLevel 5: Find the second Palaw in the Map to complete the stage\r\n";
                StartCoroutine(PalawTwoCoro());
                palawOne.SetActive(false);
                palawTwo.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && pressE.activeSelf)
        {

            if (acquiredKey == 4)
            {
                lvlComplete.text = "Level 5: Complete";
                questText.text = "Finding Palaw\r\n\r\nProceed:Go to the teleporter to enter Stage 2\r\n";
                StartCoroutine(PalawLastCoro());
                teleporter.SetActive(true);
                palawTwo.SetActive(false);
            }
        }
        //wall interactor
        //wall 1
        if (actives == true && acquiredKey == 1)
        {
            pressE.SetActive(true);
            if (pressE.activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                lvlComplete.text = "Level 1: Complete";
                questText.text = "Finding Palaw\r\n\r\nLevel 2: Find the second key to open right wall\r\n";
                StartCoroutine(WallOneCoro());
                wallAnimator.SetInteger("Open", 1);

            }
        }
        //wall 2
        if (actives == true && acquiredKey == 2)
        {
            pressE.SetActive(true);
            if (pressE.activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                lvlComplete.text = "Level 2: Complete";
                questText.text = "Finding Palaw\r\n\r\nLevel 3: Find the third key to open the whole map\r\n";
                StartCoroutine(WallTwoCoro());
                secondWall.SetActive(false);

            }
        }
        //wall 3
<<<<<<< Updated upstream
        if (actives == true && acquiredKey == 3)
=======
        if (activesc == true && acquiredKey == 3)
>>>>>>> Stashed changes
        {
            pressE.SetActive(true);
            if (pressE.activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                lvlComplete.text = "Level 3: Complete";
                questText.text = "Finding Palaw\r\n\r\nLevel 4: Find Palaw in the Map to proceed\r\n";
                StartCoroutine(WallThreeCoro());
                thirdWall.SetActive(false);
                palawOne.SetActive(true);

            }
        }

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "teleport")
        {
            Debug.Log("You are hitting the teleporter");
            StartCoroutine(SecondStager());
        }

    }
    IEnumerator WallOneCoro()
    {
        questTitle.SetActive(true);
        questTitleAnimator.SetInteger("Animator", 1);
        yield return new WaitForSeconds(6f);
        questTitleAnimator.SetInteger("Animator", 0);
        questTitle.SetActive(false);

    }
    IEnumerator SecondWallCoroutine()
    {
        playerGalawan.enabled = false;
        mainCamera.SetActive(false);
        secondwallpointer.SetActive(true);
        yield return new WaitForSeconds(2f);
        acquiredKey = 2;
        secondwallpointer.SetActive(false);
        mainCamera.SetActive(true);
        playerGalawan.enabled = true;

    }
    IEnumerator ThirdWallCoroutine()
    {
        playerGalawan.enabled = false;
        mainCamera.SetActive(false);
        thirdWallPointer.SetActive(true);
        yield return new WaitForSeconds(2f);
        acquiredKey = 3;
        thirdWallPointer.SetActive(false);
        mainCamera.SetActive(true);
        playerGalawan.enabled = true;

    }
    IEnumerator FirstKeyCoro()
    {
        yield return new WaitForSeconds(1f);
        acquiredKey = 1;
    }
    IEnumerator QuestTitleCoro()
    {
        questTitleAnimator.SetInteger("Animator", 1);
        yield return new WaitForSeconds(6f);
        questTitleAnimator.SetInteger("Animator", 0);
        questTitle.SetActive(false);
    }
    IEnumerator WallTwoCoro()
    {
        questTitle.SetActive(true);
        questTitleAnimator.SetInteger("Animator", 1);
        yield return new WaitForSeconds(6f);
        questTitleAnimator.SetInteger("Animator", 0);
        questTitle.SetActive(false);
    }
    IEnumerator WallThreeCoro()
    {
        questTitle.SetActive(true);
        questTitleAnimator.SetInteger("Animator", 1);
        yield return new WaitForSeconds(6f);
        questTitleAnimator.SetInteger("Animator", 0);
        questTitle.SetActive(false);
    }
    IEnumerator PalawTwoCoro()
    {
        yield return new WaitForSeconds(1f);
        acquiredKey = 4;
    }
    IEnumerator PalawLastCoro()
    {
        yield return new WaitForSeconds(1f);
        acquiredKey = 5;
    }
    IEnumerator SecondStager()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
<<<<<<< Updated upstream
}

=======
    IEnumerator TabCoro()
    {
        questContent.SetBool("Open", true);
        yield return new WaitForSeconds(.2f);
        questbool = true;
    }
}
>>>>>>> Stashed changes
