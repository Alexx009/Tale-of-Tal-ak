using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStopper : MonoBehaviour
{
    MouseLook cameraGalaw;
    PlayerGalaw playerGrooves;
    [SerializeField] GameObject pleyer;
    [SerializeField] GameObject cameraTwo;
    [SerializeField] GameObject cameraOne;



    void Awake()
    {
        cameraGalaw = cameraOne.GetComponent<MouseLook>();
        playerGrooves = pleyer.GetComponent<PlayerGalaw>();

    }

    void Start()
    {

        StartCoroutine(Coroutining());
        cameraOne.SetActive(false);
        playerGrooves.enabled = false;
    }
    void Update()
    {

    }
    IEnumerator Coroutining()
    {
        yield return new WaitForSeconds(6f);
        cameraOne.SetActive(true);
        playerGrooves.enabled = true;
        cameraTwo.SetActive(false);
    }
}
