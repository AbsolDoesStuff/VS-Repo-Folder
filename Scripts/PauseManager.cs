using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;  // Reference to the Pause panel

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1f)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    void PauseGame()
    {
        pausePanel.SetActive(true); // Show the pause panel
        Time.timeScale = 0f; // Pause the game
    }

    void ResumeGame()
    {
        pausePanel.SetActive(false); // Hide the pause panel
        Time.timeScale = 1f; // Resume the game
    }
}
