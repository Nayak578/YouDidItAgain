using UnityEngine;

public class BreadScript : Interactable {
    public Vector3 targetPosition = new Vector3(0.39f, 1f, 0f); // Set in Inspector
    public Vector3 targetPositionNext = new Vector3(0.39f, 0f, 0f); // Set in Inspector
    public float speed = 5f;
    public Quaternion targetRotation;
    private bool isMoving = false; // Track if movement is active
    private bool moveToNext = false;
    //private bool completeToasting = false;
    private BoxCollider collider;
    public ToBeDestructed toBeDestructed;
    public Toaster toaster;
    private void Start() {
        collider = GetComponent<BoxCollider>();
        toaster.ToastingDone += Toaster_ToastingDone;
        toaster.GetComponent<Collider>().enabled = false;
    }

    private void Toaster_ToastingDone() {
        //Debug.Log("ToasterSub");
        ToastingDone();
    }

    void Update() {
        if (isMoving) {
            if (!moveToNext) {
                
                transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, speed * Time.deltaTime);
                transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, speed * Time.deltaTime);              
                if (Vector3.Distance(transform.localPosition, targetPosition) < 0.01f) {
                    transform.localPosition = targetPosition;
                    moveToNext = true; 
                }
            } else {
                
                transform.localPosition = Vector3.Lerp(transform.localPosition, targetPositionNext, speed * Time.deltaTime);           
                if (Vector3.Distance(transform.localPosition, targetPositionNext) < 0.01f) {
                    transform.localPosition = targetPositionNext;
                    isMoving = false; 
                    moveToNext = false;
                    toaster.GetComponent<Collider>().enabled = true;
                }
            }
        }

    }

    public override void Interact() {
       // Debug.Log("BreadInteract");
        isMoving = true; // Start moving when interacted
        collider.enabled = false;
    }
    public void ToastingDone() {
        //Debug.Log("Completed Toasting");
        collider.enabled = true;
        toBeDestructed.enabled = true;
    }
}