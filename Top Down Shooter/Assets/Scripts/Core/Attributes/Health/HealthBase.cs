using UnityEngine;

public class HealthBase : MonoBehaviour {
    [Header("Health Variables")]
    [SerializeField] protected float secondsToDie = 0.5f;
    public float maxHealth = 100f;
    public float currentHealth;
    public bool isAlive = true;

    protected Animator animator;
    protected Collider2D objectCollider;

    protected virtual void Start() {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        objectCollider = GetComponent<Collider2D>();
    }

    public virtual void TakeDamage(int damage) {
        damage = UnityEngine.Random.Range(damage, damage * 2);
        bool isCritical = UnityEngine.Random.Range(0, 100) < 30;
        if (isCritical) damage *= 2;

        currentHealth -= damage;
        DamagePopup.Create(transform.position, damage, isCritical);

        if (currentHealth <= 0) {
            Die();
        }
    }

    protected virtual void Die() {
        isAlive = false;
        animator.SetBool("isAlive", isAlive);
        objectCollider.enabled = false;
        Destroy(gameObject, secondsToDie);
    }
}
