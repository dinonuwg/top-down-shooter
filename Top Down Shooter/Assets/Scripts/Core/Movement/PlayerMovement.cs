using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private float moveSpeed = 5;

    private Vector2 movement;
    private Rigidbody2D rb;


    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // WASD Movement function
    private void OnMove(InputValue value) {
        movement = value.Get<Vector2>();
    }

    // Update function but doesn't depend on the individuals framerate
    private void FixedUpdate() {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
