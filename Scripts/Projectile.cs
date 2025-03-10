using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;
    private bool hasFired = false;
    public int damage = 10;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError(gameObject.name + " - ERROR: Rigidbody missing on projectile!");
        }
        else
        {
            rb.isKinematic = false;
        }
    }

    public void Fire(Vector3 direction)
    {
        if (rb != null)
        {
            rb.velocity = direction.normalized * speed;
            hasFired = true;
            Debug.LogWarning(gameObject.name + " - FIRED in direction: " + direction);
            SoundManager.Instance.PlayProjectileFiredSound(); // Play sound when projectile is fired
        }
        else
        {
            Debug.LogError(gameObject.name + " - ERROR: Rigidbody missing, cannot fire!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning(gameObject.name + " - Projectile COLLIDED with: " + other.gameObject.name);

        if (other.CompareTag("Player")) return;

        if (other.CompareTag("Asteroid"))
        {
            Asteroid asteroid = other.GetComponent<Asteroid>();
            if (asteroid != null)
            {
                Debug.LogWarning(gameObject.name + " - DAMAGE APPLIED to: " + other.gameObject.name);
                asteroid.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
