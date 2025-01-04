using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{   
    // Healthbar variables
    public Health health;
    public Image fillImage;

    private Slider healthBar;

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
