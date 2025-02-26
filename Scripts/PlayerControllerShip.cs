using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Ship ship; // Assign your Ship GameObject in the Inspector

    private void Update()
    {
        HandleMovement();
        HandleTeleport();
    }

    private void HandleMovement()
    {
        bool moveForward = false;
        bool moveBackward = false;
        float rotation = 0f;
        bool turbo = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        // Movement and rotation (WASD)
        if (Input.GetKey(KeyCode.W))
        {
            moveForward = true; // Move forward
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveBackward = true; // Move backward
        }
        if (Input.GetKey(KeyCode.A))
        {
            rotation = 1f; // Rotate left (yaw)
        }
        if (Input.GetKey(KeyCode.D))
        {
            rotation = -1f; // Rotate right (yaw)
        }

        ship.Move(moveForward, moveBackward, turbo);
        ship.Rotate(rotation);
    }

    private void HandleTeleport()
    {
        // World space teleportation (arrow keys)
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ship.Teleport(Vector3.up);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ship.Teleport(Vector3.down);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ship.Teleport(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ship.Teleport(Vector3.right);
        }

        // Random teleport (T key)
        if (Input.GetKeyDown(KeyCode.T))
        {
            ship.RandomTeleport();
        }
    }
}
