using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    public GameObject camera;
    public PlayerInput playerInput;
    public GameObject Escape;
    public PlayerInput InteractInput;
    public class TransfromData {
        public Vector3 postion;
        public Quaternion rotation;
        public Vector3 scale;
        public TransfromData(Vector3 pos,Quaternion rot,Vector3 scl) {
            postion = pos;
            rotation = rot;
            scale = scl;
        }
    };
    private TransfromData initialTransform;
    void Start()
    {
        
        initialTransform = new TransfromData(transform.position, transform.rotation, transform.localScale);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void Interact() {
        Debug.Log("Interact");
        LockInteraction();
    }
    public virtual void LockInteraction() {
        Cursor.lockState = CursorLockMode.None;
        Escape.SetActive(true);
        transform.SetParent(camera.transform);
        transform.localPosition = new Vector3(0f, 0f, 1f); 
        transform.localRotation = Quaternion.identity;    
        playerInput.enabled = false;
        //ResetAllActions(playerInput);
        InteractInput.enabled = true;
        //ResetAllActions(InteractInput);
    }
    public virtual void UnlockInteraction() {
        
        Escape.SetActive(false);
        transform.SetParent(null);
        transform.position = initialTransform.postion;
        transform.rotation = initialTransform.rotation;
        transform.localScale = initialTransform.scale;
        
        InteractInput.enabled = false;
        //ResetAllActions(InteractInput);
        playerInput.enabled = true;
        //ResetAllActions(playerInput);
        //Cursor.lockState = CursorLockMode.Locked;
        
        LockCursor();
    }
    private void LockCursor() {
        Debug.Log("Locking Cursor");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.Log($"Cursor State: {Cursor.lockState}, Visible: {Cursor.visible}");
    }


    //private void ResetAllActions(PlayerInput input) {
    //    foreach (var action in input.actions) {
    //        if (action.enabled) {
    //            action.Disable();
    //            action.Enable();
    //        }
    //    }
    //}

}
