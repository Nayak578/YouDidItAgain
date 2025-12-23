using UnityEngine;

public class FRManager : MonoBehaviour {
    [Header("FrameRate Settings")]
    public int targetFrameRate = 60;

    void Awake() {
        QualitySettings.vSyncCount = 0; // disable VSync
        Application.targetFrameRate = targetFrameRate; // cap framerate
    }
}
