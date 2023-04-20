using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteractor : MonoBehaviour
{
    public Transform cam;
    bool active = false;
    bool actives = false;
    [SerializeField] GameObject key;
    [SerializeField] LayerMask pangkeylang;
    [SerializeField] LayerMask pangPader;
    [SerializeField] GameObject firstWall;
    [SerializeField] GameObject pressE;
    public int acquiredKey = 0;


    void Start()
    {
        pressE.SetActive(false);
        firstWall.SetActive(true);
        
    }

    void Update()
    {
        
        active = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 10f, pangkeylang);
        actives = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out RaycastHit hitInfo, 10f, pangPader);
        if (active == true)
        {
            pressE.SetActive(true);
            Debug.Log("You are hitting something");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red);
        }

        else
        {
            pressE.SetActive(false);
            Debug.Log("You are not hitting something");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.green);
        }
        if (Input.GetKeyDown(KeyCode.E) && pressE.activeSelf)
        {
            Destroy(key);
            acquiredKey = 1;
        }
        if(actives == true && acquiredKey == 1)
        {
            pressE.SetActive(true);
            if (pressE.activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                Destroy(firstWall);
            }
        }
    }
}
