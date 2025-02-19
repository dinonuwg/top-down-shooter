using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // -Variables-
    private float timer; // Variable for timer, starts at 0 seconds
    private int bulletDespawnTime = 3; // Time in seconds for bullet to despawn

    // Reference to collider
    private Collider2D bulletCollider;

    // -Main Methods-
    void Start()
    {
        bulletCollider = GetComponent<Collider2D>(); // Automatically get Collider2D component without having to drag it in the inspector
    }

    void Update()
    {   
        // If timer hasn't reached 3 seconds count up 1
        if (timer < bulletDespawnTime) {
            timer = timer + Time.deltaTime;
        } else { // When timer has reached 3 seconds delete the attached gameObjecte
            Destroy(gameObject);
        }
    }

    // When bullet collides with another object do
    private void OnTriggerEnter2D(Collider2D collision) {

        // For collision with Enemy
        if (collision.tag == "Enemy") {
            var health = collision.GetComponent<HealthBase>(); // Gets the collision objects healthbase script
            if (health != null) { // If there is health
                health.TakeDamage(10); // Take 10 DMG
            }
            Destroy(gameObject);
        }
    }
}
