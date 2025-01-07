using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.InputSystem;
using CodeMonkey.Utils;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    // - Variables -
    [SerializeField] private float acceleration = 20f;
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float deceleration = 20f;
    private Vector2 currentVelocity;

    [SerializeField] private float dashSpeed = 15f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 1f;

    private Vector2 movement; // Stores movement input
    private Rigidbody2D rb; // Reference to Rigidbody2D
    private SpriteRenderer spriteRenderer; // Reference to SpriteRenderer

    private bool isDashing = false;
    private float dashCooldownTimer = 0f;

    // - Main Methods -
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        // Move the player's Rigidbody position based on input - if the player isn't dashing
        if (!isDashing) {
            Vector2 targetVelocity = movement * moveSpeed;
            currentVelocity = Vector2.Lerp(currentVelocity, targetVelocity, (movement.sqrMagnitude > 0 ? acceleration :  deceleration) * Time.fixedDeltaTime);
            rb.MovePosition(rb.position + currentVelocity * Time.fixedDeltaTime); 
        }

        FlipSprite();

        if (dashCooldownTimer > 0) {
            dashCooldownTimer -= Time.fixedDeltaTime;
        }
    }

    // - Methods -
    private void OnMove(InputValue value)
    {
        // Get movement input from Input System and store it
        movement = value.Get<Vector2>().normalized;
    }

    private void OnDash() {
        if (dashCooldownTimer <= 0 && movement != Vector2.zero && !isDashing) {
            StartCoroutine(Dash());
        }
    }

    private void FlipSprite()
    {   
        Vector2 mousePosition = UtilsClass.GetMouseWorldPosition();
        float direction = mousePosition.x - transform.position.x;

        // Flip only the sprite by modifying SpriteRenderer's flipX property
        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = direction < 0; // Flip sprite if moving left
        }
    }

    private IEnumerator Dash() {
        Debug.Log("Dashing");
        isDashing = true;
        dashCooldownTimer = dashCooldown;

        Vector2 dashDirection = movement.sqrMagnitude > 0 ? movement.normalized : ((Vector2)UtilsClass.GetMouseWorldPosition());

        float elapsedTime = 0f;
        while (elapsedTime < dashDuration) {
            rb.MovePosition(rb.position + dashDirection * dashSpeed * Time.fixedDeltaTime);
            elapsedTime += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        Debug.Log("Dash Ended");
        isDashing = false;

    }
}