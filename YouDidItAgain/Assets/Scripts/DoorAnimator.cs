using UnityEngine;

public class DoorAnimator : MonoBehaviour {
    public RectTransform upperDoor;
    public RectTransform lowerDoor;
    public float animationDuration = 1f;
    public float openOffset = 200f; // how far the doors move to open

    private Vector2 upperClosedPos;
    private Vector2 lowerClosedPos;

    private Vector2 upperOpenPos;
    private Vector2 lowerOpenPos;

    private float elapsedTime = 0f;
    private bool isAnimating = false;

    void Awake() {
        // Save the closed positions from the Editor
        upperClosedPos = upperDoor.anchoredPosition;
        lowerClosedPos = lowerDoor.anchoredPosition;

        // Calculate open positions
        upperOpenPos = upperClosedPos + new Vector2(0, openOffset);
        lowerOpenPos = lowerClosedPos - new Vector2(0, openOffset);
    }

    void OnEnable() {
        // Start from open positions
        upperDoor.anchoredPosition = upperOpenPos;
        lowerDoor.anchoredPosition = lowerOpenPos;

        // Start animating toward closed positions
        elapsedTime = 0f;
        isAnimating = true;
    }

    void Update() {
        if (!isAnimating) return;

        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / animationDuration);

        upperDoor.anchoredPosition = Vector2.Lerp(upperOpenPos, upperClosedPos, t);
        lowerDoor.anchoredPosition = Vector2.Lerp(lowerOpenPos, lowerClosedPos, t);

        if (t >= 1f) {
            isAnimating = false;
        }
    }
}
