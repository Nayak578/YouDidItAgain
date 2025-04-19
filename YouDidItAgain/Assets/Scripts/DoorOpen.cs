using Unity.VisualScripting;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public RectTransform upperDoor;
    public RectTransform lowerDoor;
    public float animationDuration = 1f;
    public float openOffset = 200f; // how far the doors move to open
    public GameObject btn;
    public GameObject InstBtn;
    private Vector2 upperClosedPos;
    private Vector2 lowerClosedPos;

    private Vector2 upperOpenPos;
    private Vector2 lowerOpenPos;
    public GameObject canvas;
    public GameObject spwner;
    private float elapsedTime = 0f;
    private bool isAnimating = false;

    void Awake()
    {
        // Save the closed positions from the Editor
        upperClosedPos = upperDoor.anchoredPosition;
        lowerClosedPos = lowerDoor.anchoredPosition;

        // Calculate open positions
        upperOpenPos = upperClosedPos + new Vector2(0, openOffset);
        lowerOpenPos = lowerClosedPos - new Vector2(0, openOffset);
    }

    public void TriggerDoorOpen()
    {
        // Start animation from closed to open positions
        elapsedTime = 0f;
        isAnimating = true;
        btn.SetActive(false);
        InstBtn.SetActive(false);

    }

    void Update()
    {
        if (!isAnimating) return;

        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / animationDuration);

        upperDoor.anchoredPosition = Vector2.Lerp(upperClosedPos, upperOpenPos, t);
        lowerDoor.anchoredPosition = Vector2.Lerp(lowerClosedPos, lowerOpenPos, t);

        if (t >= 1f)
        {
            isAnimating = false;
            canvas.SetActive(true);
            spwner.SetActive(true);
        }
    }
}
