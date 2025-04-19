using Unity.VisualScripting;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public Canvas canva;
    public GameObject Open;
    public Spawner SP;
    public void OnStartButtonClick()
    {
        if (Open != null)
        {
            
            SP.condition = true;
            canva.gameObject.SetActive(false);
        }
    }
}
