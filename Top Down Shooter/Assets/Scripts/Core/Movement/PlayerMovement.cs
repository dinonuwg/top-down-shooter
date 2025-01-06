using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // - Variables -
    [SerializeField] private float moveSpeed = 5f;

    private Vector2 movement; // Stores movement input
    private Rigidbody2D rb; // Reference to Rigidbody2D
    private SpriteRenderer spriteRenderer; // Reference to SpriteRenderer

    // - Main Methods -
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        // Move the player's Rigidbody position based on input
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // Flip the sprite if needed
        if (movement.x != 0) // Only flip if there's horizontal movement
        {
            FlipSprite(movement);
        }
    }

    // - Methods -
    private void OnMove(InputValue value)
    {
        // Get movement input from Input System and store it
        movement = value.Get<Vector2>();
    }

    private void FlipSprite(Vector2 direction)
    {
        // Flip only the sprite by modifying SpriteRenderer's flipX property
        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = direction.x < 0; // Flip sprite if moving left
        }
    }
}