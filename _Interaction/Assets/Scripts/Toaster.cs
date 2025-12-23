using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Toaster : Interactable {
    enum State {
        start, pressing, cancelled, nothing
    }
    private State state = State.nothing;
    private Vector2 InitialPointer;
    private Vector2 FinalPointer;
    private Vector2 input;
    private BoxCollider collider;
    [SerializeField] private float slidingLength = 5f;
    public event Action ToastingDone;
    public event Action StartToastingAnimation;
    public event Action EndToastingAnimation;
    public GameObject QTE;
    public QTE_1 qteScript;
    public GameObject bread;
    public Color brown = new Color(0.6f, 0.3f, 0.1f); // RGB values (float range: 0.0 to 1.0)
    public Color goldenBrown = new Color(0.71f, 0.40f, 0.11f); // (181, 102, 28)
    public Vector3 forceOnToaster = new Vector3(0f, 10f, 5f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        qteScript.QTEResult += QteScript_QTEResult;
        playerInput = player.GetComponent<PlayerInput>();
        collider = GetComponent<BoxCollider>();
        
    }

    private void QteScript_QTEResult(QTE_1.QteResult obj) {
        QteResult(obj);
    }

    // Update is called once per frame
    void Update() {
        if (state == State.start) {
            InitialPointer = input;
            //Debug.Log("Initial: " + InitialPointer.ToString());
            state = State.nothing;
        } else if (state == State.cancelled) {
            FinalPointer = input;
            state = State.nothing;
            //Debug.Log("Final: " + FinalPointer.ToString());
            if (InitialPointer.y - FinalPointer.y > slidingLength) {
                Debug.Log("Sliding successful");
                if (StartToastingAnimation != null) {
                    StartToastingAnimation();
                }
                //Debug.Log("PlayAniamtion");

                Debug.Log("Mini game for frustration level");
                miniGame();
                //add some kind of minigame to call unlock interaction from there
                //UnlockInteraction();
            }
        }
    }
    public override void Interact() {
        LockInteraction();
        //interacting with toaster
        Debug.Log("Toaster Interaction");
        //UnlockInteraction();
    }
    public override void LockInteraction() {
        Cursor.lockState = CursorLockMode.None;

        Escape.SetActive(true);
        playerInput.enabled = false;
        InteractInput.enabled = true;
    }
    public override void UnlockInteraction() {
        Cursor.lockState = CursorLockMode.Locked;
        Escape.SetActive(false);
        collider.enabled = false;
        playerInput.enabled = true;
        InteractInput.enabled = false;
        
        if (ToastingDone != null) {
           // Debug.Log("ToastingDone");
            ToastingDone();
        }

    }
    public void GetPointerlocation(InputAction.CallbackContext context) {
        input = context.ReadValue<Vector2>();
    }
    public void OnClick(InputAction.CallbackContext context) {
        switch (context.phase) {
            case InputActionPhase.Started:
                state = State.start;
                //Debug.Log("ClickStarted");
                break;
            case InputActionPhase.Canceled:
                state = State.cancelled;
                //Debug.Log("ClickCancelled");
                break;
        }

    }
    public void miniGame() {
        QTE.SetActive(true);

    }
    public void QteResult(QTE_1.QteResult obj) {
        if (obj == QTE_1.QteResult.red) {
            RedResult();
        }else if (obj == QTE_1.QteResult.green) {
            GreenResult();
        } else {
            YellowResult();
        }
        QTE.SetActive(false);
        UnlockInteraction();
    }
    public void GreenResult() {
        bread.GetComponent<Renderer>().material.color =goldenBrown;
        EndToastingAnimation();
    }
    public void YellowResult() {
        bread.GetComponent<Renderer>().material.color = brown;
        EndToastingAnimation();
    }
    public void RedResult() {
        bread.GetComponent<Renderer>().material.color = Color.black;
        bread.GetComponent<Rigidbody>().useGravity = true;
        bread.GetComponent<Rigidbody>().AddForce(forceOnToaster,ForceMode.Force);
        EndToastingAnimation();
    }
}