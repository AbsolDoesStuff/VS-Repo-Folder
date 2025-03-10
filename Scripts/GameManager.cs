using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public List<GameObject> asteroids;
    public GameObject playerShip;
    public GameObject winScreen;
    public float winScreenDelay = 5f;
    private GameObject[] projectiles;
    private AsteroidHealthBarUI asteroidHealthBarUI;
    private int destroyedAsteroids = 0;

    private bool isGamePaused = false;

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

    void Start()
    {
        InitializeAsteroids();
        asteroidHealthBarUI = FindObjectOfType<AsteroidHealthBarUI>(); // Find UI script
    }

    void InitializeAsteroids()
    {
        asteroids = new List<GameObject>(GameObject.FindGameObjectsWithTag("Asteroid"));
        Debug.Log("Asteroid list initialized. Count: " + asteroids.Count);
    }

    void Update()
    {
        CheckVictoryCondition();
        CheckLossCondition();
    }

    public void CheckVictoryCondition()
    {
        if (asteroids.Count == 0 && !isGamePaused)
        {
            StartCoroutine(ShowWinScreenAndPause());
        }
    }

    void CheckLossCondition()
    {
        if (playerShip == null)
        {
            Debug.Log("Failure");
        }
    }

    private IEnumerator ShowWinScreenAndPause()
    {
        if (winScreen != null)
        {
            winScreen.SetActive(true);
        }
        else
        {
            Debug.LogError("winScreen is NOT assigned in the Inspector!");
            yield break;
        }

        isGamePaused = true;
        yield return new WaitForSecondsRealtime(winScreenDelay);

        isGamePaused = false;
        winScreen.SetActive(false);
        ResetGameState();
    }

    public void RemoveAsteroid(GameObject asteroid)
    {
        if (asteroids.Contains(asteroid))
        {
            asteroids.Remove(asteroid);
            destroyedAsteroids++;
            Debug.Log("Removing asteroid: " + asteroid.name);
            asteroidHealthBarUI?.UpdateHealthBar(destroyedAsteroids); // Update UI bar with the number of destroyed asteroids
            CheckVictoryCondition();
        }
    }

    public void ResetGameState()
    {
        Debug.Log("Resetting game state");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isGamePaused = false;
    }
}
