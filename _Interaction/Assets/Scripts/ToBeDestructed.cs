using UnityEngine;

public class ToBeDestructed : MonoBehaviour
{
    public BreadScript breadScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        breadScript.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Interact() {
        Debug.Log("Bread is being eaten");
        Destroy(gameObject);
    }
}
