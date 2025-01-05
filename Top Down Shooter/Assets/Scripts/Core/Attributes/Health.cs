using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // -Variables-
    public float maxHealth = 5f;
    public float currentHealth;

    public bool isAlive = true;

    [SerializeField] private GameObject floatingTextPrefab;

    // -Main Methods-
    void Start()
    {
        currentHealth = maxHealth; // Set currentHealth to maxHealth at start
    }

    // -Methods-

    // Function to call in other scripts, if u want to call it you do TakeDamage("X") X = how much dmg u want to take
    public void TakeDamage(int damage) {
        ShowDamage(damage.ToString());
        currentHealth -= damage;

        if (currentHealth <= 0) {
            Die();
        }
    }

    void ShowDamage(string damageText) {
        if (floatingTextPrefab) {
            GameObject prefab = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = damageText;
        }
    }

    void Die() {
        Destroy(gameObject);
    }

}
