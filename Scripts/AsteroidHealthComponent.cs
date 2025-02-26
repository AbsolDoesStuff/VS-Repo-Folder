using UnityEngine;

public class AsteroidHealthComponent : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("Asteroid Initialized with Max Health: " + maxHealth);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Asteroid Current Health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " has died");
        // Call the GameManager to remove the asteroid
        GameManager.Instance.RemoveAsteroid(gameObject);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Projectile(Clone)")
        {
            DamageComponent damageComponent = collision.gameObject.GetComponent<DamageComponent>();
            if (damageComponent != null)
            {
                TakeDamage(damageComponent.damage);
                Destroy(collision.gameObject); // Destroy the projectile on impact
            }
        }
    }
}
