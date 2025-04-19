using UnityEngine;

public class Effectsm : MonoBehaviour
{
    public GameObject basicHit;
    public GameObject RedHit;
    public GameObject CyanHit;
    public GameObject GreenHit;
    public GameObject YellowHit;
    public AudioSource src;
    public AudioClip sfx1, sfx2, sfx3, sfx4, sfx5;
    public Collider floorCollider;
    public float destroyDelay = 2f;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f)) {
                // Check if clicked object is NOT an orb
                if (hit.collider.GetComponent<Orb>() == null) {
                    // Spawn default basicHit on floor
                    GameObject effect = Instantiate(basicHit, hit.point, Quaternion.identity);
                    Destroy(effect, destroyDelay);
                }
            }
        }
    }

    // Call this from other scripts like Orb to spawn a color-based effect
    public void SpawnHitEffect(string color, Vector3 position) {
        GameObject effect = null;

        switch (color) {
            case "Red":
                effect = RedHit;
                src.clip = sfx1;
                src.Play();
                break;
            case "Cyan":
                effect = CyanHit;
                src.clip = sfx2;
                src.Play();
                break;
            case "Green":
                effect = GreenHit;
                src.clip = sfx3;
                src.Play();
                break;
            case "Yellow":
                effect = YellowHit;
                src.clip = sfx4;
                src.Play();
                break;
            default:
                effect = basicHit;
                //src.clip = sfx5;
                //src.Play();
                break;
        }

        if (effect != null) {
            GameObject instance = Instantiate(effect, position, Quaternion.identity);
            Destroy(instance, destroyDelay);
        }
    }
    public void playsound() {
        src.clip = sfx5;
        src.Play();
    }
}
