using UnityEngine;

public class HealthBarShowOnHit : MonoBehaviour // Currently used for EnemyHealthBar 01/04/2025
{
    // -Variables-
    public Health health;

    public GameObject healthBar;

    // -Main Methods-
    void Start()
    {
        healthBar.SetActive(false);
    }

    void Update()
    {   
        // If currentHealth isnt equal to maxHealth enable healthBar
        if (health.currentHealth != health.maxHealth && health.currentHealth != 0) {
            healthBar.SetActive(true);
        } else if (health.currentHealth <= 0) {

        }
            
    }


    
}
