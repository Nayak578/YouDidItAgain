using UnityEngine;

public class DestroyOnClick : MonoBehaviour
{
    public GameManager GM;

    private void Start()
    {
        if (GM == null)
        {
            GM = FindAnyObjectByType<GameManager>();
            if (GM == null)
            {
                Debug.LogError("GameManager not found in the scene!");
                return;
            }
        }
    }

    private void OnMouseDown()
    {
        if (GM == null)
        {
            Debug.LogError("GameManager reference is missing!");
            return;
        }

        if (gameObject.CompareTag("Red_Orb"))
        {
            if (GM.red_variable)
            {
                if (GM.switching)
                {
                    Debug.Log("wrong");

                }
                else
                {
                    Debug.Log("Good");
                }
            }
            else
            {
                if (GM.switching)
                {
                    Debug.Log("Good");
                }
                else
                {
                    Debug.Log("wrong");
                }
            }
        }

        // This is till red orb

        if (gameObject.CompareTag("Cyan_Orb"))
        {
            if (GM.cyan_variable)
            {
                if (GM.switching)
                {
                    Debug.Log("wrong");

                }
                else
                {
                    Debug.Log("Good");
                }
            }
            else
            {
                if (GM.switching)
                {
                    Debug.Log("Good");
                }
                else
                {
                    Debug.Log("wrong");
                }
            }
        }

        //Till cyan orb

        if (gameObject.CompareTag("Yellow_Orb"))
        {
            if (GM.yellow_variable)
            {
                if (GM.switching)
                {
                    Debug.Log("wrong");

                }
                else
                {
                    Debug.Log("Good");
                }
            }
            else
            {
                if (GM.switching)
                {
                    Debug.Log("Good");
                }
                else
                {
                    Debug.Log("wrong");
                }
            }
        }

        //Till yellow orb

        if (gameObject.CompareTag("Green_Orb"))
        {
            if (GM.green_variable)
            {
                if (GM.switching)
                {
                    Debug.Log("wrong");

                }
                else
                {
                    Debug.Log("Good");
                }
            }
            else
            {
                if (GM.switching)
                {
                    Debug.Log("Good");
                }
                else
                {
                    Debug.Log("wrong");
                }
            }
        }

        Destroy(gameObject);
    }
}
