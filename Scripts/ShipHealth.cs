using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Ship took damage");
        
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.PlayShipHitSound(); //  Play ship hit sound when damaged
        }
        else
        {
            Debug.LogError("SoundManager instance is NULL!");
        }
    }
}