using UnityEngine;
public class FPSDisplay : MonoBehaviour
{
    private float fps;
    public TMPro.TextMeshProUGUI fpsCounterText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("GetFps",0,0.3f);
    }

    // Update is called once per frame
    void GetFps()
    {
        fps = (int)(1f / Time.unscaledDeltaTime);
        fpsCounterText.text = "FPS: " + fps.ToString();
    }
}
