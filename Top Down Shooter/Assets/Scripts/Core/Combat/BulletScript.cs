using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Collider2D bulletCollider;

    private float timer;
    private int bulletDespawnTime = 3;

    void Start()
    {
        bulletCollider = GetComponent<Collider2D>();    
    }


    void Update()
    {
        if (timer < bulletDespawnTime) {
            timer = timer + Time.deltaTime;
        } else {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
    }
}
