using UnityEngine;

public class Toasting : MonoBehaviour
{
    public GameObject bread;
    public float leverOffset = 0.7f;
    public Toaster toaster;
    public float speed = 5f;
    private bool startMovementOfLever = false;
    private bool endMovementOfLever = false;
    public Vector3 newPos;
    public Vector3 endPos;
    public Vector3 BreadPos= new Vector3(0.389999986f, 1.29999995f, -0.029999999f);
    public Vector3 ToastPos = new Vector3(0.25f, 2f, 0f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        toaster.StartToastingAnimation += Toaster_StartToastingAnimation;
        toaster.EndToastingAnimation += Toaster_EndToastingAnimation;
    }

    private void Toaster_EndToastingAnimation() {
        EndRoasting();
    }

    private void Toaster_StartToastingAnimation() {
        StartToasting();
    }

    // Update is called once per frame
    void Update()
    {
        if (startMovementOfLever) {
           
            transform.localPosition = Vector3.Lerp(transform.localPosition, newPos, speed * Time.deltaTime);
            bread.transform.localPosition = Vector3.Lerp(bread.transform.localPosition, BreadPos, speed * Time.deltaTime);
            if (Vector3.Distance(transform.localPosition,newPos) < 0.01f) {    
                transform.localPosition = newPos;
                startMovementOfLever = false;
            }
        }
        if (endMovementOfLever) {
            transform.localPosition = Vector3.Lerp(transform.localPosition, endPos, speed * Time.deltaTime);
            bread.transform.localPosition = Vector3.Lerp(bread.transform.localPosition, ToastPos, speed * Time.deltaTime);
            if (Vector3.Distance(transform.localPosition, endPos) < 0.01f) {
                transform.localPosition = endPos;
                endMovementOfLever = false;
            }
        }
    }
    public void StartToasting() {
        
        startMovementOfLever = true;
    }
    public void EndRoasting() {
        endMovementOfLever = true;
    }
}
