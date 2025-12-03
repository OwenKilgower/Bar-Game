using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

   
    
    [SerializeField] Camera cam;
    public float followSpeed = 8f;
    public float minX = -1f;
    public float maxX = 1f;

    public float startOffset;

    private void Start()
    {
        startOffset = Vector3.Dot(transform.position - cam.transform.position, cam.transform.right);
    }

    public void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        
        mousePos.z = cam.WorldToScreenPoint(transform.position).z;
        Vector3 world = cam.ScreenToWorldPoint(mousePos);

        float mouseOffset = Vector3.Dot(world - cam.transform.position, cam.transform.right);

        Vector3 targetPos = cam.transform.position +
                            cam.transform.forward * (transform.position.z - cam.transform.position.z) +
                            cam.transform.right * mouseOffset;

        targetPos.y = transform.position.y;
        targetPos.z = transform.position.z;


        transform.position = targetPos;
    }
    
}
