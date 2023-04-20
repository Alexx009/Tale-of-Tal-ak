using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public Button damageButton;
    public Image healthBar;
    public float damageAmount = 10f;

    private float currentHealth;
    

    void Start()
    {
        currentHealth = healthBar.fillAmount;
    }

		void Update()
	{
		// check if the space key is pressed
		if (Input.GetKeyDown(KeyCode.J))
		{
			DamagePlayer();
		}
	}

    void DamagePlayer()
    {
        currentHealth -= damageAmount / 100f;
        healthBar.fillAmount = currentHealth;

        if (currentHealth <= 0)
        {
            // Player is dead
            Debug.Log("Player is dead");
        }
    }
}
