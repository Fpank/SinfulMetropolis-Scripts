using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody2D rb;                     // Reference to the Rigidbody2D component
    private GravityManager gravityManager;      // Reference to the GravityManager instance

    private void Awake()                        // Initialize the obstacle
    {
        rb = GetComponent<Rigidbody2D>();                                // Get the Rigidbody2D component
        gravityManager = FindObjectOfType<GravityManager>();            // Find the GravityManager instance in the scene
    }

    private void Start()                                                // Start the obstacle
    {
        if (gravityManager != null)                                     // Check if the GravityManager instance is found
        {
            rb.gravityScale = gravityManager.GetCurrentGravityScale();  // Set the initial gravity scale
        }
        else
        {
            Debug.LogError("GravityManager instance not found.");       // Log an error if the GravityManager instance is not found
        }
    }
}
