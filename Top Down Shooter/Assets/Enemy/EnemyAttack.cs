using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int collisionDmg = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var playerHealth = collision.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(collisionDmg);
            }
        }
    }
}