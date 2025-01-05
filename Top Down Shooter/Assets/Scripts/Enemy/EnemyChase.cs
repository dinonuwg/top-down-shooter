using UnityEngine;

public class EnemyChase : MonoBehaviour
{   
    // -Variables-
    public GameObject player;
    public float enemySpeed = 3f;

    private float distance;

    // -Main Methods-
    void Start()
    {
        FindPlayer();
    }


    void FixedUpdate()
    {   // Gets distance between enemy and player
        distance = Vector2.Distance(transform.position, player.transform.position);

        // Not using currently, will use later to flip enemy i think
        Vector2 direction = player.transform.position - transform.position;

        // Moves enemy towards player
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, enemySpeed * Time.fixedDeltaTime);
    }
    
    // -Methods-
    void FindPlayer() {
        player = GameObject.FindWithTag("Player");

        // Check if the player was found
        if (player == null) {
            Debug.LogError("Player GameObject not found! Ensure the Player GameObject is tagged as 'Player'.");
        }
    }
}
