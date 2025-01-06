using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{   
    // -Variables-
    public Health health;
    public Image fillImage;

    private Slider healthBar;

    // -Main Methods-
    void Awake()
    {
        healthBar = GetComponent<Slider>();
    }

    void Update()
    {
        float fillValue = health.currentHealth / health.maxHealth;
        healthBar.value = fillValue;
    }
}
