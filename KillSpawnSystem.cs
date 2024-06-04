using System.Collections;
using UnityEngine;

public class KillSpawnSystem : MonoBehaviour
{
    Vector2 startPos;                         // Initial position of the player
    Rigidbody2D playerRb;                    // Reference to the player's Rigidbody2D
    public GameManager gameManager;         // Reference to the GameManager
    private bool isDead;                   // Flag to track if the player is dead
    public Timer timer;                   // Reference to the Timer script
    private bool isDuringDelay;          // Flag to track if the player is in the delay period

    private void Awake()                // Initialize the player's Rigidbody2D
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Start()                       // Initialize the starting position of the player
    {
        startPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)         // Handle collisions with obstacles
    {
        if (collision.CompareTag("Obstacle"))
        {
            
            if (!isDuringDelay)                                 // Check if the timer is up and if we are in the delay period
            {
                
                Die();                                          // Trigger ending
            }
            else
            {
                
                gameManager.SecretEnding();                     // secret ending

            }
        }
    }

    void Die()                                                  // Handle the player's death
    {
        isDead = true;                                            // Set the player as dead
        gameObject.SetActive(false);                             // Disable the player's game object
        gameManager.gameOver();                                 // Trigger the game over event
        CombinedAudioManager.instance.PlaySFX(2);              // Play the death sound effect
    }

    IEnumerator Respawn(float duration)                         // Respawn the player after a delay
    {
        playerRb.simulated = false;                             // Disable the player's Rigidbody2D
        playerRb.velocity = Vector2.zero;                       // Set the player's velocity to zero
        transform.localScale = Vector3.zero;                    // Scale the player down
        yield return new WaitForSeconds(duration);              // Wait for the specified duration
        transform.position = startPos;                          // Reset the player's position
        transform.localScale = Vector3.one;                     // Reset the player's scale
        playerRb.simulated = true;                              // Enable the player's Rigidbody2D
    }

    public void SetDuringDelay(bool value)                      // Set the flag for the delay period
    {
        isDuringDelay = value;
    }
}
