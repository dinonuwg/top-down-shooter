using UnityEngine;

public class DestroyInSeconds : MonoBehaviour
{   // SCRIPT TO DESTROY TEMPORARY GAMEOBJECTS, TWEAK LENGTH IN INSPECTOR
    [SerializeField] private float secondsToDestroy = 1f;
    void Start()
    {   // Destroy gameObject in secondsToDestroy amount of seconds
        Destroy(gameObject, secondsToDestroy);
    }
}
