using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;                        // Reference to the game over UI
    public GameObject SecretEndingUI;                    // Reference to the secret ending UI
    public GameObject player;                           // Reference to the player GameObject
    private bool secretEndingTriggered = false;         // Flag to track if the secret ending has been triggered

    private void Start()                                // Load saved volume settings and apply them
    {
        
        float musicVolume = PlayerPrefs.GetFloat("Music", 1f);
        float sfxVolume = PlayerPrefs.GetFloat("SFXV", 1f);
        float masterVolume = PlayerPrefs.GetFloat("Master", 1f);
        CombinedAudioManager.instance.SetMusicVolume(musicVolume);
        CombinedAudioManager.instance.SetSFXVolume(sfxVolume);
        CombinedAudioManager.instance.SetMasterVolume(masterVolume);
    }

    public void gameOver()                               // Handle game over
    {
        if (!secretEndingTriggered)                       // Check if the secret ending has not been triggered
            gameOverUI.SetActive(true);                  // Activate the game over UI
        if (player != null)                              // Deactivate the player
            player.SetActive(false);
    }

    public void restart()                               // Restart the game
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);               // Reload the current scene
    }

    public void Home()                                  // Go to the main menu
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()                              // Quit the game
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void SecretEnding()                          // Trigger the secret ending
    {
        secretEndingTriggered = true;                   // Set the secret ending flag to true

        SecretEndingUI.SetActive(true);                // Activate the secret ending screen
    }
}
