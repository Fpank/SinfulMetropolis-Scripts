using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;    // Singleton instance of the player controller
    public float speed = 10.0f;                 // Movement speed
    public float jumpForce = 10.0f;             // Jump force
    public float gravity = 9.8f;                // Gravity

    private Rigidbody2D rb;                     // Rigidbody component
    private bool isGrounded = false;            // Flag to track if the player is grounded

    private bool isWalking = false;               // Flag to track if the walk SFX is playing
    private float walkSFXCooldown = 0.5f;        // Cooldown time between walk SFX plays
    private float walkSFXTimer = 0f;            // Timer to track cooldown

    private void Awake()                        // Initialize the player controller
    {
        if (instance == null)                   // Ensure only one instance of the player controller exists
            instance = this;
        rb = GetComponent<Rigidbody2D>();       // Get the Rigidbody2D component
    }

    void Update()                               // Update the player controller
    {
        float horizontalInput = Input.GetAxis("Horizontal");    // Get the horizontal input
        bool jumpInput = Input.GetButtonDown("Jump");           // Check for jump input

        if (isGrounded && jumpInput)                            // Jump if grounded and jump input is detected
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);         // Apply jump force
            isGrounded = false;
            CombinedAudioManager.instance.PlaySFX(1);                   // Play jump SFX
        }

        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);      // Update player movement

        if (!isGrounded)                                                // Apply gravity if not grounded
        {
            rb.velocity += Vector2.down * gravity * Time.deltaTime;     // Apply gravity
        }

        if (horizontalInput != 0 && isGrounded)                         // Check for walk SFX cooldown
        {
            walkSFXTimer += Time.deltaTime;                             // Increment walk SFX timer
            if (!isWalking && walkSFXTimer >= walkSFXCooldown)           // Play walk SFX if cooldown is met
            {
                isWalking = true;
                CombinedAudioManager.instance.PlaySFX(0);               // Play walk SFX
                walkSFXTimer = 0f;                                      // Reset timer after playing SFX
            }
        }
        else
        {
            isWalking = false;                                          // Reset walk SFX flag
        }
    }

    void OnCollisionEnter2D(Collision2D collision)                       // Handle collisions
    {
        if (collision.gameObject.CompareTag("Ground"))                  // Check if the collision is with the ground
        {
            isGrounded = true;                                         // Set grounded flag to true
        }
    }
}
