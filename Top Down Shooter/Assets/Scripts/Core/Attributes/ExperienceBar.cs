using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour {
    // -Variables-
    public Experience experience; // reference to the experience script
    public Image fillImage;

    private Slider xpBar;

    // -Main Methods-
    void Awake() {
        xpBar = GetComponent<Slider>();
        xpBar.maxValue = experience.maxExperiencePerLevel; // Set the sliders max value
    }

    void Update() {
        UpdateExperienceBar();
    }
    // -Methods-
    private void UpdateExperienceBar() {
        // Update the slider value based on the current experience
        xpBar.value = experience.currentExperience;

        if (fillImage != null ) {
            // Changes fill color based on level :3
            fillImage.color = Color.Lerp(Color.yellow, Color.green, (float)experience.currentExperience / experience.maxExperiencePerLevel);
        }
    }
}
