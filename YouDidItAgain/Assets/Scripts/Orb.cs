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

        if ((state && !GM.switching) || (!state && GM.switching))
        {
            Debug.Log("Good");
            IncreaseMethod();
            Effectsm FX = GM.GetComponent<Effectsm>();
            if (FX != null)
            {
                FX.SpawnHitEffect(color.ToString(), transform.position);
            }
        }
        else {
            Debug.Log("Wrong");
            GM.TriggerGameOver1();
           
        }
        Destroy(gameObject);

    }

    private void IncreaseMethod()
    {
        GM.IncreaseScore();
    }
    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Floor")) {
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
                GM.DecreaseScore();
            }
                Destroy(gameObject);
        }
    }
    
}
