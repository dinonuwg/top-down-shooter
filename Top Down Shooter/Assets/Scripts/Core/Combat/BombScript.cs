using UnityEngine;

public class BombScript : MonoBehaviour
{
    // - Variables - 
    private float timer;
    [SerializeField] private float explosionTime = 3f; // Time until explosion

    // References
    private Collider2D bombCollider;
    private Animator animator;

    public bool isTicking = true;
    public bool isExploding = false;

    [SerializeField] private int explosionDamage = 20;
    [SerializeField] private float explosionRadius = 4f;

    void Start()
    {
        bombCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();

        bombCollider.enabled = false;
        animator.SetBool("isTicking", isTicking);
    }

    void Update()
    {
        if (isTicking && timer <  explosionTime) {
            timer += Time.deltaTime;
        } else if (isTicking) {
            Explode();
        }
    }

    private void Explode() {
        isTicking = false;
        isExploding = true;

        animator.SetBool("isTicking", isTicking);
        animator.SetBool("isExploding", isExploding);

        bombCollider.enabled = true;

        // Detects all the objects in the explosion radius
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D hit in hits) {
            var health = hit.GetComponent<HealthBase>();
            if (health != null) {
                health.TakeDamage(explosionDamage);
            }
        }
        Destroy(gameObject, 0.5f);
    }

    // Debug, to see the explosion radius
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }


}
