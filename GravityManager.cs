using UnityEngine;

public class GravityManager : MonoBehaviour
{
    [SerializeField] private float initialGravityScale = 0.2f;              // Initial gravity scale
    [SerializeField] private float gravityIncrement = 0.15f;               // Amount to increase gravity scale
    [SerializeField] private float timeInterval = 15f;                    // Time interval for increasing gravity in seconds
    public Timer timer;                                                  // Reference to the Timer script

    public static GravityManager instance;                              // Singleton instance

    private float currentGravityScale;                                 // Current gravity scale
    private float nextIncreaseTime;                                   // Time when the next gravity increase should happen

    private void Awake()                                            // Initialize the GravityManager
    {
        if (instance == null)                                      // Ensure only one instance of the GravityManager exists
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);                         // Ensure the GravityManager persists across scenes
    }

    private void Start()                                      // Initialize the GravityManager
    {
        if (timer == null)                                   // Check if the Timer reference is set
        {
            Debug.LogError("Timer reference is not set in GravityManager.");
            return;
        }

        currentGravityScale = initialGravityScale;                      // Initialize the current gravity scale
        nextIncreaseTime = timer.remainingTime - timeInterval;         // Schedule the first gravity increase
    }

    private void Update()                                            // Update the GravityManager
    {
        if (timer.remainingTime <= nextIncreaseTime)                // Check if the timer has reached the next increase time
        {
            IncreaseGravityScale();
            nextIncreaseTime -= timeInterval;                       // Schedule the next increase
        }
    }

    private void IncreaseGravityScale()                             // Increase the gravity scale
    {
        currentGravityScale += gravityIncrement;                                     // Increase the gravity scale by the specified increment
        Debug.Log("Increased gravity scale to: " + currentGravityScale);            // Log the new gravity scale
    }

    public float GetCurrentGravityScale()                                          // Get the current gravity scale
    {
        return currentGravityScale;
    }
}
