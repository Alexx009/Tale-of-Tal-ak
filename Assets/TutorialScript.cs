using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{
    public PlayerGalaw player;
    public MouseLook camera;
    public GameObject tutorialTitle;
    public CharacterController playerController;
    public TMP_Text title;
    public GameObject keysUI;
    public float defaultHP = 100;
    public GameObject fall;
    public GameObject teleporter;
    public Transform playerDestination;
    public Transform backPortal;
    public GameObject playerChar;
    public GameObject objectToPress;
    public Material unpressed;
    public Material pressed;
    public Transform cam;
    public float maxDistance = 10f; // Maximum distance the raycast can travel
    public LayerMask box;
    bool teleporterism = false;
    public GameObject lastTeleport;
    public GameObject lastCollider;




    void Awake()
    {
        playerController = playerController.GetComponent<CharacterController>();
        player = player.GetComponent<PlayerGalaw>();
        camera = camera.GetComponent<MouseLook>();
        lastTeleport.SetActive(false);


    }
    void Start()
    {
        player.enabled = false;
        camera.enabled = false;
        keysUI.SetActive(false);
        tutorialTitle.SetActive(true);
        StartCoroutine(Coroutines());

    }
    

    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

       
        RaycastHit hit;

       
        if (Physics.Raycast(ray, out hit, maxDistance, box) && Input.GetMouseButtonDown(0))
        {
          objectToPress.GetComponent<Renderer>().material = pressed;
            teleporterism = true;
            lastTeleport.SetActive(true);
            Debug.Log("Hit " + hit.transform.name);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            keysUI.SetActive(true);
         
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {

            keysUI.SetActive(false);
            return;
        }
    }
    
    IEnumerator Coroutines()
    {
        yield return new WaitForSeconds(4f);
        camera.enabled = true;
        tutorialTitle.SetActive(false);
        StartCoroutine(TextCoro());
    }
    IEnumerator TextCoro()
    {
        tutorialTitle.SetActive(true);
        title.text = "Use mouse to look around";
        yield return new WaitForSeconds(4f);
        tutorialTitle.SetActive(false);
        StartCoroutine(TextCoroTwo());
    }
    IEnumerator TextCoroTwo()
    {
        tutorialTitle.SetActive(true);
        title.text = "Use W,A,S,D keys to move";
        yield return new WaitForSeconds(4f);
        player.enabled = true;
        tutorialTitle.SetActive(false);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "instakill")
        {
            defaultHP = defaultHP - 100f;
            print("The collision is working");
            StartCoroutine(PlayerTele());
        }
        if (other.gameObject.tag == "TutorialPortal")
        {
            StartCoroutine(BackTele());
        }
        if (other.gameObject.tag == "lastTele")
        {

            StartCoroutine(LastTele());
        }
    }
    IEnumerator PlayerTele()
    {
        playerController.enabled = false;
        camera.enabled = false;
        yield return new WaitForSeconds(1f);
        camera.enabled = true;
        playerChar.transform.position = playerDestination.position;
        playerController.enabled=true;
    }
    IEnumerator BackTele()
    {
        playerController.enabled = false;
        camera.enabled = false;
        yield return new WaitForSeconds(1f);
        camera.enabled = true;
        playerChar.transform.position = backPortal.position;
        playerController.enabled = true;
        StartCoroutine(LastTripCoro());
    }
    IEnumerator LastTripCoro()
    {
        tutorialTitle.SetActive(true);
        playerController.enabled = false;
        title.text = "Press the block to reveal portal";
        yield return new WaitForSeconds(4f);
        playerController.enabled = true;
    }
    IEnumerator LastTele()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
   
