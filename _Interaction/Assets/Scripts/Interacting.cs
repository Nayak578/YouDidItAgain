using UnityEngine;
using UnityEngine.InputSystem;

public class Interacting : MonoBehaviour
{
    public GameObject interactCanvas;
    private Interactable inter;
    private bool canInteract=false;
    private ToBeDestructed destructable;
    private bool canDestruct = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CanInteract(InputAction.CallbackContext context) {
        if (context.phase == InputActionPhase.Started) {
            if (canInteract&& inter.isActiveAndEnabled) {
                {
                    interactCanvas.SetActive(false);
                    inter.Interact();
                }
            } else if (canDestruct&& destructable.isActiveAndEnabled) {
                interactCanvas.SetActive(false);
                destructable.Interact();
            }
        }
    }
    private void OnTriggerEnter(Collider other) {
        inter = other.GetComponent<Interactable>();
        if (inter != null) {
            if (inter.isActiveAndEnabled) {
                interactCanvas.SetActive(true);
                canInteract = true;
            }
        }
        destructable = other.GetComponent<ToBeDestructed>();
        if (destructable != null) {
            if (destructable.isActiveAndEnabled) {
                //Debug.Log("Destructable");
                interactCanvas.SetActive(true);
                canDestruct = true;
            }
        }

    }
    private void OnTriggerExit(Collider other) {
        interactCanvas.SetActive(false);
        canInteract = false;
        canDestruct = false;
    }
}
