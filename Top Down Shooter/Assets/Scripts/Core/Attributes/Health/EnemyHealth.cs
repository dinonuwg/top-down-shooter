using UnityEngine;

public class EnemyHealth : HealthBase { // Uses HealthBase as base script
    [Header("Enemy Settings")]
    [SerializeField] private int experienceToGive = 1;
    private Experience xp;

    protected override void Start() {
        base.Start();
        FindPlayerXPScript();
    }

    private void FindPlayerXPScript() {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null) {
            xp = player.GetComponent<Experience>();
        }
        else {
            Debug.LogError("Player GameObject not found! Can't assign experience.");
        }
    }

    protected override void Die() {
        if (xp != null) {
            xp.GainExperience(experienceToGive);
        }
        base.Die();
    }
}
