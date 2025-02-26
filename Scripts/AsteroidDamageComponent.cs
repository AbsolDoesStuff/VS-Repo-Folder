using UnityEngine;

public class AsteroidDamageComponent : MonoBehaviour
{
    public int damage = 10;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ClonedAsteroid"))
        {
            HealthComponent health = collision.gameObject.GetComponent<HealthComponent>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
            // Destroy the projectile on impact
            Destroy(gameObject);
        }
    }
}
