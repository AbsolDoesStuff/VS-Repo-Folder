using UnityEngine;

public class Ship : MonoBehaviour
{
    public float moveSpeed = 10f; // units per second
    public float rotateSpeed = 100f; // degrees per second
    public float turboSpeedMultiplier = 2f;
    public float teleportRange = 5f;

    public void Move(bool moveForward, bool moveBackward, bool turbo)
    {
        float deltaTime = Time.deltaTime;
        float currentSpeed = turbo ? moveSpeed * turboSpeedMultiplier : moveSpeed;

        // Forward movement in the direction the ship is facing
        if (moveForward)
        {
            transform.Translate(Vector3.up * currentSpeed * deltaTime, Space.Self);
        }
        if (moveBackward)
        {
            transform.Translate(Vector3.down * currentSpeed * deltaTime, Space.Self);
        }
    }

    public void Rotate(float rotation)
    {
        float deltaTime = Time.deltaTime;
        // Rotation on the z-axis (yaw)
        transform.Rotate(0, 0, rotation * rotateSpeed * deltaTime);
    }

    public void Teleport(Vector3 direction)
    {
        transform.position += direction * teleportRange;
    }

    public void RandomTeleport()
    {
        Vector3 randomDirection = Random.insideUnitSphere;
        randomDirection.z = 0; // Keep teleportation on a flat plane
        transform.position += randomDirection * teleportRange;
    }
}
