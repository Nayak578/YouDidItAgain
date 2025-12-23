using UnityEngine;
using UnityEngine.InputSystem;

public class Looking : MonoBehaviour {
    public Transform body;
    public float xsensitivity = 100f;
    public float ysensitivity = 100f;

    private float xRotation = 0f;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Look(InputAction.CallbackContext context) {
        Vector2 input = context.ReadValue<Vector2>();

        float mouseX = input.x * xsensitivity * Time.deltaTime;
        float mouseY = input.y * ysensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp to prevent over-rotation

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Vertical (pitch)
        body.Rotate(Vector3.up * mouseX); // Horizontal (yaw)
    }
}
