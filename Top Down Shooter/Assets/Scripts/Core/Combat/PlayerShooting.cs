using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour {

    // Variables for shooting
    [SerializeField] private GameObject bulletPrefab; // Which bullet that is gonna be shot out, drag into the player script in inspector
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed = 10f;

    // Reference to camera
    private Camera mainCamera;

    private void Awake() {
        mainCamera = Camera.main;
    }

    // When M1 or Enter is pressed start the Shoot function
    private void OnAttack(InputValue value) {
        if (value.isPressed) {
            Shoot();
        }
    }

    // There is probably better code for this, will change in the future
    private void Shoot() {
        // Gets the Vector3 position (X,Y,Z) of cursor
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mouseWorldPosition.z = 0; // Set z to 0 because this is a 2D game

        // Calculate the direction from the firePoint to the mouse position
        Vector2 shootDirection = (mouseWorldPosition - firePoint.position).normalized;

        // Create a bullet with the preset prefab at the firePoint position
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // if bullet exists give it a velocity with bulletSpeed
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        if (bulletRb != null) {
            bulletRb.linearVelocity = shootDirection * bulletSpeed;
        }
    }

}

