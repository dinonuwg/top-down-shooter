using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float initialMinimumSpawnTime = 10f;
    [SerializeField] private float initialMaximumSpawnTime = 15f;
    [SerializeField] private float spawnRate = 0.95f; // The smaller the decimal the faster the spawnrate (0.95f = 5% faster spawnrate, 0.90f = 10%)
    [SerializeField] private float minimumAllowedSpawnTime = 0.5f; // Can't spawn faster than 1 per 0.5 seconds


    [SerializeField] private float minimumSpawnTime;
    [SerializeField] private float maximumSpawnTime;

    private float timeUntilSpawn;
    private float elapsedTime; // Not used currently

    void Awake()
    {   
        // Sets the spawn times to their initial/start value
        minimumSpawnTime = initialMinimumSpawnTime;
        maximumSpawnTime = initialMaximumSpawnTime;

        // Start timer until spawn, spawns the first enemies faster
        SetTimeUntilSpawn("Start");
    }

    void Update()
    {
        elapsedTime += Time.deltaTime; // Counts up from 0 in seconds
        timeUntilSpawn -= Time.deltaTime; // Counts down

        // If the timer reaches 0 spawn enemy, increase spawn rate and start the timer again
        if (timeUntilSpawn <= 0) {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            AdjustSpawnRate();
            SetTimeUntilSpawn("Timer") ;
        }
    }

    // Starts timer until spawn
    private void SetTimeUntilSpawn(string spawnTimerType) {
        // If the timer is set to instant spawn enemy after 1 second
        if (spawnTimerType == ("Start")) {
            timeUntilSpawn = Random.Range(1, 20);
            // If timer is set to timer spawn within the random range of minimumSpawnTime and maximumSpawnTime
        } else if (spawnTimerType == ("Timer")) {
            timeUntilSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);
        } else {
            Debug.Log("spawnTimerType is set to a value that doesn't exist");
        }

    }

    // Adjusts the spawn rates and ensures that spawn times doesnt go over the allowed spawn times with Mathf.Max
    private void AdjustSpawnRate() { 
                           // Mathf.Max compares two values and picks out the higher one
        minimumSpawnTime = Mathf.Max(minimumSpawnTime * spawnRate, minimumAllowedSpawnTime);
        maximumSpawnTime = Mathf.Max(maximumSpawnTime * spawnRate, minimumAllowedSpawnTime + 0.1f);
    }
}
