using UnityEngine;

public class InstructionScript : MonoBehaviour
{
    public GameObject instructions;
    public GameObject canvas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartInstruction() {
        canvas.SetActive(false);
        instructions.SetActive(true);
    }
    public void BackInstruction() {
        canvas.SetActive(true);
        instructions.SetActive(false);
    }
}
