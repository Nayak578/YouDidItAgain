using UnityEngine;

public class Orb_Script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameManager GM;
    void Start()
    {
        bool red_variable=GM.GetComponent<GameManager>().red_variable;
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.GetComponent<GameManager>().red_variable) {
            Debug.Log("Red");
        }
    }
    private void OnMouseDown() {
        if (GM.GetComponent<GameManager>().red_variable) {
            if (GM.GetComponent<GameManager>().switching) {
                //gameover
            }
            else {
                //score++
            }
        }
    }
}
