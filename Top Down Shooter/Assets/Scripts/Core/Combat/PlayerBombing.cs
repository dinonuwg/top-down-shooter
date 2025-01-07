using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBombing : MonoBehaviour {

    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private Camera mainCamera;

    private float timer;

    private void Awake() {
        mainCamera = Camera.main;
    }

    private void Update() {
        timer -= Time.deltaTime;
    }

    private void OnAttack2(InputValue value) {
        if (value.isPressed && timer <= 0) {
            Bomb();
            timer = 2f;
        }
    }

    private void Bomb() {
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Instantiate(bombPrefab, mousePos, Quaternion.identity);
    }
}
