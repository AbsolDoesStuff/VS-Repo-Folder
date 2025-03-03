using UnityEngine;


public class Asteroid : MonoBehaviour
{
    public float speed = 5f;
    public int maxHealth = 30;
    private int currentHealth;
    private Rigidbody rb;

    void Awake()
    {
        currentHealth = maxHealth;
        Debug.LogWarning(gameObject.name + " - ASTEROID SPAWNED with health: " + currentHealth);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.back * speed;
            Debug.Log(gameObject.name + " - MOVING with speed: " + speed);
        }
        else
        {
            Debug.LogError(gameObject.name + " - ERROR: MISSING Rigidbody!");
        }
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0) return;
        if (currentHealth <= 0) return;

        Debug.LogWarning(gameObject.name + " - HIT! Damage Taken: " + damage);
        currentHealth -= damage;
        Debug.LogWarning(gameObject.name + " - REMAINING HEALTH: " + currentHealth);

        if (currentHealth <= 0)
        {
            DestroyAsteroid();
        }
    }

    private void DestroyAsteroid()
    {
        Debug.LogError(gameObject.name + " - DESTROYED!");
        GameManager.Instance?.RemoveAsteroid(gameObject);
        Destroy(gameObject);
    }
}