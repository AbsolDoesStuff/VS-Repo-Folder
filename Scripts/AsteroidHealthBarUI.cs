using UnityEngine;
using UnityEngine.UI;

public class AsteroidHealthBarUI : MonoBehaviour
{
    public Image AsteroidHealthFill; // Reference to the health bar fill image
    private int totalAsteroids = 10; // Set reference asteroid count to 10
    private int destroyedAsteroids;

    void Start()
    {
        InitializeHealthBar();
    }

    void InitializeHealthBar()
    {
        GameObject[] asteroidObjects = GameObject.FindGameObjectsWithTag("Asteroid");
        totalAsteroids = asteroidObjects.Length;
        destroyedAsteroids = 0;

        if (AsteroidHealthFill != null)
        {
            AsteroidHealthFill.fillAmount = 1f; // Start full
            Debug.Log("Health bar initialized: Total Asteroids = " + totalAsteroids);
        }
        else
        {
            Debug.LogError("Health bar fill image is not assigned in the Inspector!");
        }
    }

    public void UpdateHealthBar(int currentDestroyedAsteroids)
    {
        destroyedAsteroids = currentDestroyedAsteroids;
        if (AsteroidHealthFill != null)
        {
            // Calculate the exact percentage of health reduction
            float fillAmount = Mathf.Clamp01(1f - ((float)destroyedAsteroids / totalAsteroids));
            AsteroidHealthFill.fillAmount = fillAmount;
            Debug.Log($"Health bar updated: Destroyed = {destroyedAsteroids}, Remaining = {totalAsteroids - destroyedAsteroids}, Fill = {fillAmount}");
        }
        else
        {
            Debug.LogError("Health bar fill reference is missing!");
        }
    }
}
