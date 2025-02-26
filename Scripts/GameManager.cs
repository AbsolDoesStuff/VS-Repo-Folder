using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public List<GameObject> asteroids; // List of all asteroids in the scene
    public GameObject playerShip; // Reference to the player ship

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        CheckVictoryCondition();
        CheckLossCondition();
    }

    void CheckVictoryCondition()
    {
        // Check if all asteroids are destroyed
        if (asteroids.Count == 0)
        {
            Debug.Log("Victory");
            // Add any additional logic for victory (e.g., show victory screen)
        }
    }

    void CheckLossCondition()
    {
        // Check if the player ship is destroyed
        if (playerShip == null)
        {
            Debug.Log("Failure");
            // Add any additional logic for loss (e.g., show loss screen)
        }
    }

    // Call this method when an asteroid is destroyed to update the list
    public void RemoveAsteroid(GameObject asteroid)
    {
        if (asteroids.Contains(asteroid))
        {
            asteroids.Remove(asteroid);
        }
    }
}
