using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] float speed = 150f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform cameraTransform;

    private Vector2 inputVector;

    public void OnMove(InputAction.CallbackContext context) {
        inputVector = context.ReadValue<Vector2>();
        if (context.canceled) inputVector = Vector2.zero;
    }

    void FixedUpdate() {
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        camForward.y = 0f;
        camRight.y = 0f;

        camForward.Normalize();
        camRight.Normalize();

        Vector3 move = camRight * inputVector.x + camForward * inputVector.y;
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
        //if (Input.GetKeyDown(KeyCode.Mouse0)) {
           // Debug.Log("MouseClick");
       // }
    }
    
}
