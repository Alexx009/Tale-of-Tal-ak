using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public Image healthBar;
    public float damageAmount = 10f;
    public float health = 100f;
    public playerFall playerDead;
    public GameObject dead;
    private float currentHealth;
    private Vector3 ogPos;

    void Start()
    {
        ogPos = dead.transform.position;
        currentHealth = healthBar.fillAmount;
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.P)){
            health = 0;
            DamagePlayer();
        }
    }

    public void DamagePlayer()
    {
        currentHealth -= damageAmount / health;
        healthBar.fillAmount = currentHealth;
        audioSource.PlayOneShot(audioClip);
        if (currentHealth <= 0)
        {
            health = 100f;
            healthBar.fillAmount = health;
            dead.transform.position = transform.position;
        }
    }
    public void returnDead(){
        dead.transform.position  = ogPos;
    }
}
