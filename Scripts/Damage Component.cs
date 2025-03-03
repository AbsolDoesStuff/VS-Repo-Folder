using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    public int damage = 10;

    void OnCollisionEnter(Collision collision)
    {
        HealthComponent health = collision.gameObject.GetComponent<HealthComponent>();
        if (health != null)
        {
            health.TakeDamage(damage);
            
            // Ensure we only destroy the gameObject if it still exists
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
    }
}
