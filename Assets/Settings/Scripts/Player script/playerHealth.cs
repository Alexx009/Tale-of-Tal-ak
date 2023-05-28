using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public DialogueScripStage2 dialogueScripStage2;
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
    }

    public void DamagePlayer()
    {
        currentHealth -= damageAmount / health;
        healthBar.fillAmount = currentHealth;
        dialogueScripStage2.Hurt();


        if (currentHealth <= 0)
        {
            health = 100f;
            healthBar.fillAmount = health;
            dead.transform.position = transform.position;
        }
    }
}
