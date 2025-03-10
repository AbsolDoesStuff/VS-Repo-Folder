using UnityEngine;

public class SimpleShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 10f;
    private float fireRate = 0.2f;
    private float nextFire = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = firePoint.up * projectileSpeed; // Moves the projectile up relative to ship
        }

        projectile.tag = "PlayerProjectile"; 
        projectile.transform.SetParent(null);
        Destroy(projectile, 5f);
    }
}
