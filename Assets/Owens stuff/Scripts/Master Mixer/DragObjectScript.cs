using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragObjectScript : MonoBehaviour
{
    private Vector3 mOffset;

    private float mZCoord;
    public bool mouseHold;
   

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        //Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseWorldPos();
       
        mouseHold = true;
    }

    void OnMouseUp()
    {
        mouseHold = false;
        
        //resets movement when let go to mimic dropping properly
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && mouseHold == true)
        {
            
            transform.Rotate(0f, -0.4f, 0f);
        }

        if (Input.GetKey(KeyCode.D) && mouseHold == true)
        {

            transform.Rotate(0f, 0.4f, 0f);
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        //x,y coordinates
        Vector3 mousePoint = Input.mousePosition;

        //z coordinates
        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        gameObject.transform.position = GetMouseWorldPos() + mOffset;
    }
}