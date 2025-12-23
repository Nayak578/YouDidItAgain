using UnityEngine;
using UnityEngine.InputSystem;

public class RotateObject : MonoBehaviour {
    public float xsensitivity = 20f;
    public float ysensitivity = 20f;

    private float xRotation = 0f;  // vertical rotation (pitch)
    private float yRotation = 0f;  // horizontal rotation (yaw)

    public void RotateInteractable(InputAction.CallbackContext context) {
        Vector2 input = context.ReadValue<Vector2>();

        float mouseX = input.x * xsensitivity * Time.deltaTime;
        float mouseY = input.y * ysensitivity * Time.deltaTime;

        xRotation += mouseY;   // invert Y if you want standard mouse look
        yRotation += mouseX;

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
