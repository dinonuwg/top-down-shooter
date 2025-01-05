using System.Collections;
using System.Threading;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{   
    // -Variables-
    [SerializeField] private int enemyDamage = 1;
    [SerializeField] private int damageInterval = 1;

    private Coroutine damageCoroutine;

    // -Main Methods-
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        // If collision is with player
        if (collision.gameObject.CompareTag("Player"))
        {   
            // Get health component from the player
            var playerHealth = collision.GetComponent<Health>();
            // If there is a health component and coroutine isnt running
            if (playerHealth != null && damageCoroutine == null)
            {   
                // Start the coroutine for damage
                damageCoroutine = StartCoroutine(DamagePlayerOverTime(playerHealth));
            }
        }
    }

    // When collision is stopped
    private void OnTriggerExit2D(Collider2D collision) {
        // Check if the existing objected has player tag and that the coroutine is running
        if (collision.gameObject.CompareTag("Player") && damageCoroutine != null) {
            // Stop the coroutine thats doing damage
            StopCoroutine(damageCoroutine);
            damageCoroutine = null; // Sets IEnumerator loop to false making it stop
        }
    }

    // Coroutine to apply damage to the player repeateadly at set intervals
    private IEnumerator DamagePlayerOverTime(Health playerHealth) {
        while (true) { // Infinite loop that keeps applying damage until stopped
            playerHealth.TakeDamage(enemyDamage);
            yield return new WaitForSeconds(damageInterval);
        }
    }

}