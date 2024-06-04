using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;              // Reference to the pause menu GameObject

    public void Pause()                                 // Pause the game
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;                             // Pause the game time
    }

    public void Home()                              // Go to the main menu
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;                         // Resume the game time
    }

    public void Resume()                           // Resume the game
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;                       // Resume the game time
    }
}
