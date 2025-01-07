using CodeMonkey.Utils;
using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{   
    // Create a Damage Popup
    public static DamagePopup Create(Vector3 position, int damageAmount, bool isCriticalHit) {
        Transform damagePopupTransform = Instantiate(GameAssets.i.damagePopupPrefab, position, Quaternion.identity);

        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount, isCriticalHit);

        return damagePopup;
    }

    private static int sortingOrder;

    private const float DISAPPEAR_TIMER_MAX = 1f;

    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;
    private Vector3 moveVector;

    private void Awake() {
         textMesh = transform.GetComponent<TextMeshPro>();
    }
    public void Setup(int damageAmount, bool isCriticalHit) {
        textMesh.SetText(damageAmount.ToString());
        if (!isCriticalHit ) {
            // Normal Hit
            textMesh.fontSize = 12; 
            textColor = UtilsClass.GetColorFromString("FFFF4D");
        } else {
            // Critical hit
            textMesh.fontSize = 16;
            textColor = UtilsClass.GetColorFromString("FF3C3C");
        }
        textMesh.color = textColor;
        disappearTimer = DISAPPEAR_TIMER_MAX;


        sortingOrder++;
        textMesh.sortingOrder = sortingOrder;
        moveVector = new Vector3(1, 1) * 5f;
    }

    private void Update() {
        transform.position += moveVector * Time.deltaTime;
        moveVector -= moveVector * 8f * Time.deltaTime;

        if (disappearTimer > DISAPPEAR_TIMER_MAX * .5f) {
            // First half of popup lifetime
            float increaseScaleAmount = 1f;
            transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
        } else {
            // Second half of popuplifetime
            float decreaseScaleAmount = 1f;
            transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
        }

        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0) {
            // Start disappearing
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a < 0) {
                Destroy(gameObject);
            }
        }
    }
}
