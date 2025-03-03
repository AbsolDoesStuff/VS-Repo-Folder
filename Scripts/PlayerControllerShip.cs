using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Ship ship;

    private void Update()
    {
        HandleMovement();
        HandleTeleport();
    }

    private void HandleMovement()
    {
        bool moveForward = Input.GetKey(KeyCode.W);
        bool moveBackward = Input.GetKey(KeyCode.S);
        float rotation = 0f;
        bool turbo = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        if (Input.GetKey(KeyCode.A)) rotation = 1f;
        if (Input.GetKey(KeyCode.D)) rotation = -1f;

        ship.Move(moveForward, moveBackward, turbo);
        ship.Rotate(rotation);
    }

    private void HandleTeleport()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) ship.Teleport(Vector3.up);
        if (Input.GetKeyDown(KeyCode.DownArrow)) ship.Teleport(Vector3.down);
        if (Input.GetKeyDown(KeyCode.LeftArrow)) ship.Teleport(Vector3.left);
        if (Input.GetKeyDown(KeyCode.RightArrow)) ship.Teleport(Vector3.right);
        if (Input.GetKeyDown(KeyCode.T)) ship.RandomTeleport();
    }
}
