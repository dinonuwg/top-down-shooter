using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public GameObject player;
    public float enemySpeed = 3f;

    private float distance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {   // Gets distance between enemy and player
        distance = Vector2.Distance(transform.position, player.transform.position);

        // Not using currently, will use later to flip enemy i think
        Vector2 direction = player.transform.position - transform.position;

        // Moves enemy towards player
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, enemySpeed * Time.fixedDeltaTime);
    }
}
