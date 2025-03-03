using UnityEngine;

public class DeathComponent : MonoBehaviour
{
    public void Die()
    {
        Destroy(gameObject);
    }
}
