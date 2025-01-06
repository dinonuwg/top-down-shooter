using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    // -Variables-
    [Header("Health Variables")]
    [SerializeField] private float secondsToDie = 0.5f; // How long it takes to die
    public float maxHealth = 5f;
    public float currentHealth;
    public bool isAlive = true;

    [Header("Enemy Settings")] // Header in the inspector for better sorting
    [SerializeField] private int experienceToGive = 1;
    public bool isEnemy;

    private Collider2D objectCollider;
    private Animator animator;
    private GameObject player;
    private Experience xp;

    // -Main Methods-
    void Start()
    {
        currentHealth = maxHealth; // Set currentHealth to maxHealth at start
        animator = GetComponent<Animator>();
        objectCollider = GetComponent<Collider2D>();
        if (isEnemy) {
            FindPlayerXPScript();
        }
    }

    // -Methods-
    void FindPlayerXPScript() {
        player = GameObject.FindWithTag("Player");
        xp = player.GetComponent<Experience>();

        // Check if the player was found
        if (player == null) {
            Debug.LogError("Player GameObject not found! Can't assign experience.");
        }
    }

    // Function to call, in other scripts, if u want to call it you do TakeDamage("X") X = how much dmg u want to take
    public void TakeDamage(int damage) {
        currentHealth -= damage;

        if (currentHealth <= 0) {
            Die();
        }
    }

    void Die() {
        if (isEnemy) {
            xp.GainExperience(experienceToGive);
        }
        isAlive = false;
        animator.SetBool("isAlive", isAlive);
        objectCollider.enabled = false;
        Destroy(gameObject, secondsToDie);
    }

}
