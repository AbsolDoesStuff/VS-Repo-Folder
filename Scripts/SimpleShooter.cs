using UnityEngine;

public class SimpleShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 10f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Assuming "Fire1" is your shoot button
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        projectile.name = "Projectile(Clone)"; // Ensure the cloned projectiles are named correctly
        projectile.tag = "ClonedProjectile"; // Assign the tag to the cloned projectile
        
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Apply velocity in the direction the firePoint is facing
            rb.linearVelocity = firePoint.forward * projectileSpeed;
        }

        // Ensure the projectile is instantiated at the root level, not as a child of the Canvas
        projectile.transform.SetParent(null, true);
    }
}
