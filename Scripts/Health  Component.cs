using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public HealthBarUI healthBarUI;  // Reference to the HealthBarUI script
    public GameObject youDiedPanel;  // Reference to the "You Died" panel

    void Start()
    {
        currentHealth = maxHealth;
        healthBarUI.SetMaxHealth(maxHealth);
        youDiedPanel.SetActive(false); // Ensure the panel is hidden at the start
        Debug.Log("Max Health Set: " + maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Current Health: " + currentHealth);
        healthBarUI.SetHealth(currentHealth, maxHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player has died!");
        youDiedPanel.SetActive(true); // Show the "You Died" panel
        Time.timeScale = 0f; // Pause the game
    }
}