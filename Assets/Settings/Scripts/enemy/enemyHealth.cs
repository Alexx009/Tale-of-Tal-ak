using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour {
    public int maxHealth = 100;
    public int currentHealth;
    public Image healthBar;

    private void Start() {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount) {
        currentHealth -= damageAmount;

        if (currentHealth <= 0) {
            currentHealth = 0;
            Die();
        }

        UpdateHealthBar();
    }

    private void UpdateHealthBar() {
        float healthPercentage = (float)currentHealth / (float)maxHealth;
        healthBar.fillAmount = healthPercentage;
    }

    private void Die() {
        // Add any death logic here, such as playing a death animation or removing the object from the scene.
        Destroy(gameObject);
    }
}
