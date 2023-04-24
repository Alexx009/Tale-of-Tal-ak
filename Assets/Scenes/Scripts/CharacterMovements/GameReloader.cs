using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReloader : MonoBehaviour
{
    PlayerGalaw playerGalaw;
    [SerializeField] GameObject FPSplayer;
    public float defaultHP;
    void Awake()
    {
        playerGalaw = FPSplayer.GetComponent<PlayerGalaw>();
    }

    // Update is called once per frame
    void Update()
    {
        defaultHP = playerGalaw.defaultHP;
        if (defaultHP <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
