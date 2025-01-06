using UnityEngine;

public class EnemyChase : MonoBehaviour
{   
    // -Variables-
    public GameObject player;
    public float enemySpeed = 3f;
    public bool isChasing = false;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private float distance;
    private Vector2 lastDirection;
    

    // -Main Methods-
    void Start()
    {
        FindPlayer();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void FixedUpdate()
    {   
        ChasePlayer();
    }
    
    // -Methods-
    void FindPlayer() {
        player = GameObject.FindWithTag("Player");

        // Check if the player was found
        if (player == null) {
            Debug.LogError("Player GameObject not found! Ensure the Player GameObject is tagged as 'Player'.");
        } 
    }

    void ChasePlayer() {
        // Gets distance between enemy and player
        distance = Vector2.Distance(transform.position, player.transform.position);

        // Not using currently, will use later to flip enemy i think
        Vector2 direction = (player.transform.position - transform.position).normalized;

        // Moves enemy towards player
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, enemySpeed * Time.fixedDeltaTime);

        isChasing = true;
        animator.SetBool("isChasing", isChasing);

        FlipSprite(direction);
    }

    void FlipSprite(Vector2 direction) {
        // Flip only the sprite by modifying SpriteRenderer's flipX property
        if (spriteRenderer != null) {
            spriteRenderer.flipX = direction.x < 0; // Flip sprite if moving left
        }

        // Update the last direction for further use if needed
        lastDirection = direction;
    }
}
