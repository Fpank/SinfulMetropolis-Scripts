using System.Collections;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;                         // Reference to the timer text
    [SerializeField] public float remainingTime;                       // Remaining time
    public GameManager gameManager;                                   // Reference to the GameManager
    public bool isCheckingForSecretEnding = false;                   // Flag to check if the secret ending is being checked
    public bool secretEndingTriggered = false;                      // Flag to indicate if the secret ending has been triggered
    public GameObject player;                                      // Reference to the player GameObject
    private KillSpawnSystem killSpawnSystem;                      // Reference to the KillSpawnSystem component



    void Start()                                // Initialize the timer
    {
        // Get the KillSpawnSystem component from the player GameObject

        if (player != null)
        {
            killSpawnSystem = player.GetComponent<KillSpawnSystem>();
        }
    }

    void Update()                           // Update the timer
    {
        if (remainingTime > 0)              // Decrease the remaining time
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime <= 0)        
        {
            remainingTime = 0;                            // Set the remaining time to 0 when the timer is up
            timerText.color = Color.red;                 // Change the timer text color to red
            StartCoroutine(GameOverWithDelay());        // Start the game over coroutine with a delay
        }


        // Format the remaining time as minutes and seconds

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    IEnumerator GameOverWithDelay()             // Coroutine for game over with a delay
    {
        if (killSpawnSystem != null)           // Set the delay flag in the KillSpawnSystem
        {
            killSpawnSystem.SetDuringDelay(true);
        }

        yield return new WaitForSeconds(10f);       // Wait for 10 seconds

        // Deactivate player and trigger game over screen

        if (player != null)
        {
            player.SetActive(false);
        }

        gameManager.gameOver();                 // Trigger the game over event in the GameManager

    }



    public bool IsTimeUp()                  // Check if the time is up
    {
        return remainingTime <= 0;
    }


}

