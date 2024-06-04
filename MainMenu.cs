using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()                               // Method to start the game
    {
        SceneManager.LoadSceneAsync("Level 1");          // Load the "Level 1" scene asynchronously
    }

    public void QuitGame()                              // Method to quit the game
    {
        Application.Quit();                             // Quit the application
    }
}