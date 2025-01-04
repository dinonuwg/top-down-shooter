using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {

    // Movement variables
    [SerializeField] private float moveSpeed = 5;

    private Vector2 movement;

    // Component references
    private Rigidbody2D rb;

    // Awake is called when the script is loading, before start basically
    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // WASD Movement function, gets the Vector2 value of the direction you want to move and stores it in a variable
    private void OnMove(InputValue value) {
        movement = value.Get<Vector2>();
    }

    // Update function but doesn't depend on the individuals framerate
    private void FixedUpdate() {
        // Move the players rigidbody position to position + Vector2 direction * moveSpeed * deltatime 
        // Deltatime which is used in physics code to make it work basically? Otherwise you are moving at 1000mph
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
