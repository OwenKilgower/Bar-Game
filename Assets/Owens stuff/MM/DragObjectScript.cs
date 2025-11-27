using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragObjectScript : MonoBehaviour
{
    private Vector3 mOffset;

    private float mZCoord;
    public GameObject rotatingObject;
    Quaternion targetRotation;

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        //Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseWorldPos();
       
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            
            transform.Rotate(0f, 0f, 0.4f);
        }

        if (Input.GetKey(KeyCode.D))
        {

            transform.Rotate(0f, 0f, -0.4f);
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
