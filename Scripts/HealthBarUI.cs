using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    public RectTransform healthFill;

    public void SetMaxHealth(int maxHealth)
    {
        healthFill.localScale = new Vector3(1, 1, 1); // Ensure the fill starts at full size
    }

    public void SetHealth(int currentHealth, int maxHealth)
    {
        float healthPercentage = (float)currentHealth / maxHealth;
        healthFill.localScale = new Vector3(healthPercentage, 1, 1);
    }
}