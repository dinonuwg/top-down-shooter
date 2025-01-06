using UnityEngine;

public class Experience : MonoBehaviour
{
    // -Variables-
    public int maxExperiencePerLevel = 10; // Max experience needed to level up
    public int currentExperience = 0; // Current experience in the current level
    public int currentLevel = 1; // Starting level
    public int maxLevel = 10; // Maximum level the player can reach

    // -Main Methods-
    void Start()
    {
        Debug.Log($"Starting at Level {currentLevel} with {currentExperience}/{maxExperiencePerLevel} XP.");
    }
    void Update()
    {

    }

    // -Methods-
    public void GainExperience(int experience) {
        currentExperience += experience;

        // Level up while currentExperience exceeds or meets maxExperiencePerLevel
        while (currentExperience >= maxExperiencePerLevel) {
            if (currentLevel < maxLevel) {
                currentExperience -= maxExperiencePerLevel; // Subtract required XP for the level
                currentLevel++; // Increase the level
                Debug.Log($"Leveled up! New Level: {currentLevel}. Remaining XP: {currentExperience}");
            }
            else {
                currentExperience = 0; // Cap experience at 0 if max level reached
                Debug.Log("Max level reached!");
                break;
            }
        }
    }
}
