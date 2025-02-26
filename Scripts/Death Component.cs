using UnityEngine;

public class DeathComponent : MonoBehaviour
{
    public void Die()
    {
        // When Dead
        Destroy(gameObject);
        Debug.Log("GameObject destroyed!");
    }
}