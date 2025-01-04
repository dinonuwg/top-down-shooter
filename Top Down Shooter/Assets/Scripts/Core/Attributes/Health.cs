using UnityEngine;

public class Health : MonoBehaviour
{
    // Health variables
    public float maxHealth = 5f;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // Set currentHealth to maxHealth at start
    }

    // Function to call in other scripts, if u want to call it you do TakeDamage("X") X = how much dmg u want to take
    public void TakeDamage(int damage) {
        currentHealth -= damage;

        if (currentHealth <= 0) {
            // Die
        }
    }

}
