using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Health variables
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Function to call in other scripts, if u want to call it you do TakeDamage("X") X = how much dmg u want to take
    void TakeDamage(int damage) {
        currentHealth -= damage;

        if (currentHealth <= 0) {
            // Die
        }
    }

}
