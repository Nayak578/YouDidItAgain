using System;
using UnityEngine;

public class QTE_1 : MonoBehaviour
{
    public float greenPosX;
    public float yellowPosX;
    public float startX;
    public float endX;
    public float speed;
    public Rigidbody2D rb;
    public RectTransform rt;
    public float offset;
    public enum QteResult {
    red, yellow, green
    }

    public event Action<QteResult> QTEResult;

    void Start()
    {
        rb.linearVelocityX = speed;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (rt.localPosition.x < greenPosX) {
                if (QTEResult != null) {
                    QTEResult(QteResult.red);
                    gameObject.SetActive(false);
                }

            } else if (rt.localPosition.x < yellowPosX) {
                Debug.Log("In the green");
                if (QTEResult != null) {
                    QTEResult(QteResult.green);
                    gameObject.SetActive(false);
                }
            } else {
                Debug.Log("In the yelloow");
                if (QTEResult != null) {
                    QTEResult(QteResult.yellow);
                    gameObject.SetActive(false);
                }
            }
        }
        if (rt.localPosition.x<startX) {
           // Debug.Log("Changing");
            rb.linearVelocityX = speed;
        }
        if (rt.localPosition.x > endX ) {
            rb.linearVelocityX = -speed;
        }
        //Debug.Log(rt.localPosition.ToString());
        
    }
}
