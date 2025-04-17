using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject Borde_1;
    public GameObject Borde_2;
    public GameObject Borde_3;
    public bool change = false;
    public bool switching = false;
    public bool red_variable = false;
    public bool green_variable = false;
    public bool cyan_variable = false;
    public bool yellow_variable = false;

    private Color[] hdrColors;
    Renderer renderer1;
    Renderer renderer2;
    Renderer renderer3;
    /// <summary>
    /// Color(0f, 1f, 0f) -green
    /// Color(1f, 0f, 0f) -red
    /// Color(0f, 1f, 1f) -cyan
    /// Color(1f, 1f, 0f) -yellow
    /// </summary>]
    public float intensity = 3f;
    private void Awake() {
        renderer1 = Borde_1.GetComponent<Renderer>();
        renderer2 = Borde_2.GetComponent<Renderer>();
        renderer3 = Borde_3.GetComponent<Renderer>();
        hdrColors = new Color[4];
        Color hdrRed = new Color(1f, 0f, 0f);
        hdrRed = hdrRed * intensity;
        Color hdrCyan = new Color(0f, 1f, 1f);
        hdrCyan = hdrCyan * intensity;
        Color hdrYellow = new Color(1f, 1f, 0f);
        hdrYellow = hdrYellow * intensity;
        Color hdrGreen = new Color(0f, 1f, 0f);
        hdrGreen = hdrGreen * intensity;
        hdrColors[0] = hdrRed;
        hdrColors[1] = hdrCyan;
        hdrColors[2] = hdrYellow;
        hdrColors[3] = hdrGreen;
        Randomize_color();
    }
    private void Update() {
        if (change) {
            Randomize_color();
            change = false;
        }
    }
    private void Randomize_color() {
        ResetVariables();
        int i = Random.Range(0, 4);
        int j = Random.Range(0, 4);
        int k = Random.Range(0, 4);
        renderer1.material.SetColor("_Color", hdrColors[i]);
        renderer2.material.SetColor("_Color", hdrColors[j]);
        renderer3.material.SetColor("_Color", hdrColors[k]);
        SetVariables(i);
        SetVariables(j);
        SetVariables(k);
    }
    private void SetVariables(int i) {
        switch (i) {
            case 0: {
                    red_variable = true;
                    break;
                }
            case 1: {
                    cyan_variable = true;
                    break;
                }
            case 2: {
                    yellow_variable = true;
                    break;
                }
            case 3: {
                    green_variable = true;
                    break;
                }
        }
    }
    private void ResetVariables () {
        red_variable = false; 
        green_variable = false;
        cyan_variable = false;
        yellow_variable = false;
}
    private void SwitchVariables() {
        red_variable =!red_variable;
        green_variable = !green_variable;
        cyan_variable = !cyan_variable;
        yellow_variable = !yellow_variable;
    }
}
