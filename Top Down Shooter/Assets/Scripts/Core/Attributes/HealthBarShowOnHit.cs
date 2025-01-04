using UnityEngine;

public class HealthBarShowOnHit : MonoBehaviour // Currently used for EnemyHealthBar 01/04/2025
{
    // Healthbar variables
    public Health health;

    public GameObject healthBar;

    void Start()
    {
        healthBar.SetActive(false);
    }

    void Update()
    {   
        // If currentHealth isnt equal to maxHealth enable healthBar
        if (health.currentHealth != health.maxHealth) {
            healthBar.SetActive(true);
        }
    }
}
