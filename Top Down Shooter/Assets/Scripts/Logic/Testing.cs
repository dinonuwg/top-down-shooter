using CodeMonkey.Utils;
using UnityEngine;
using UnityEngine.Rendering;

public class Testing : MonoBehaviour
{
    private void Start() {
        
    }
    
    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            bool isCriticalHit = Random.Range(0, 100) < 30;
            DamagePopup.Create(UtilsClass.GetMouseWorldPosition(), 300, isCriticalHit);
        }
    }

}
