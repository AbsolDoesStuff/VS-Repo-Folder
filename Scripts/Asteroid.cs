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
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.back * speed;
        }
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0 || currentHealth <= 0) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            SoundManager.Instance.PlayAsteroidDestroyedSound(); // Play sound when asteroid is destroyed
            DestroyAsteroid();
        }
    }

    private void DestroyAsteroid()
    {
        GameManager.Instance?.RemoveAsteroid(gameObject);
        Destroy(gameObject);
    }
}
