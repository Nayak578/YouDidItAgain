using UnityEngine;

public class Orb : MonoBehaviour {
    public enum OrbColor { Red, Cyan, Yellow, Green }
    public OrbColor color;

    private GameManager GM;

    private void Start() {
        GM = FindAnyObjectByType<GameManager>();
        if (GM == null) {
            Debug.LogError("GameManager not found!");
        }
    }

    private void OnMouseDown() {
        if (GM == null) return;

        bool state = false;
        switch (color) {
            case OrbColor.Red:
                state = GM.red_variable;
                break;
            case OrbColor.Cyan:
                state = GM.cyan_variable;
                break;
            case OrbColor.Yellow:
                state = GM.yellow_variable;
                break;
            case OrbColor.Green:
                state = GM.green_variable;
                break;
        }

        if ((state && !GM.switching) || (!state && GM.switching)) {
            Debug.Log("Good");
            // maybe GM.IncreaseScore();
        } else {
            Debug.Log("Wrong");
            // maybe GM.GameOver();
        }
        Effectsm FX = GM.GetComponent<Effectsm>();
        if (FX != null) {
            FX.SpawnHitEffect(color.ToString(), transform.position);
        }

        Destroy(gameObject);
    }
}
