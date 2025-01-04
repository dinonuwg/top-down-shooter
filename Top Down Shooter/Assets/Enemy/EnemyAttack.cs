using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int collisionDmg = 10;
    [SerializeField] private Health playerHealth;

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {
            playerHealth = GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(collisionDmg);
            }
        }
    }
}