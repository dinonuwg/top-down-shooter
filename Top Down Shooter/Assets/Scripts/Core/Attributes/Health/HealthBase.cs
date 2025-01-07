using System.Collections;
using UnityEngine;

public class HealthBase : MonoBehaviour {
    [Header("Health Variables")]
    [SerializeField] protected float secondsToDie = 0.5f;
    public float maxHealth = 100f;
    public float currentHealth;
    public bool isAlive = true;

    [Header("Blink Variables")]
    [SerializeField] protected float blinkDuration = 0.5f;
    [SerializeField] protected float blinkInterval = 0.1f;
    protected bool isBlinking = false;

    // References
    protected Animator animator;
    protected Collider2D objectCollider;
    protected SpriteRenderer spriteRenderer;

    protected virtual void Start() {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        objectCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public virtual void TakeDamage(int damage) {
        damage = UnityEngine.Random.Range(damage, damage * 2);
        bool isCritical = UnityEngine.Random.Range(0, 100) < 30;
        if (isCritical) damage *= 2;

        currentHealth -= damage;
        DamagePopup.Create(transform.position, damage, isCritical);

        StartCoroutine(BlinkSprite());

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

    protected IEnumerator BlinkSprite() {
        if (isBlinking) yield break;

        isBlinking = true;
        Color originalColor = spriteRenderer.color;
        Color blinkColor = Color.red;
        float elapsedTime = 0f;

        while (elapsedTime < blinkDuration) {
            spriteRenderer.color = blinkColor;
            yield return new WaitForSeconds(blinkInterval);

            spriteRenderer.color = originalColor;
            yield return new WaitForSeconds(blinkInterval);

            elapsedTime += blinkInterval * 2;
        }

        spriteRenderer.color = originalColor;
        isBlinking = false;
    }
}
