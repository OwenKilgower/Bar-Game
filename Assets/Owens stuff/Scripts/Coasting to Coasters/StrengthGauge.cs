using System;
using UnityEngine;

public class StrengthGuage : MonoBehaviour
{
    [SerializeField] private GameObject glassPrefab;

    [SerializeField] private float throwForce = 10f;
    [SerializeField] private float maxForce = 20f;

    [SerializeField] private Transform throwPosition;
    [SerializeField] private Transform glassMover;
    [SerializeField] private Vector3 throwDirection = new Vector3(0f, 0f, 1f);
    
    [SerializeField] private LineRenderer throwLine;
    
    private bool isCharging = false;
    private float chargeTime = 0f;
    
    private float amountLeft = 5f;
    private float currentAmount = 0f;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentAmount < amountLeft)
        {
            StartThrowing();
        }
        if (isCharging && currentAmount < amountLeft)
        {
            ChargeThrow();
        }

        if (Input.GetKeyUp(KeyCode.Space) && currentAmount < amountLeft)
        {
            ReleaseThrow();
            currentAmount += 1f;
        }
    }

    void StartThrowing()
    {
        isCharging = true;
        chargeTime = 0f;

        throwLine.enabled = true;
    }

    void ChargeThrow()
    {
        chargeTime += Time.deltaTime;
        
        Vector3 glassVelocity = (throwPosition.transform.right + throwDirection).normalized * Mathf.Min(chargeTime * throwForce, maxForce);
        ShowTrajectory(throwPosition.position + throwPosition.right, glassVelocity);
    }
    void ReleaseThrow()
    {
        ThrowGlass(Mathf.Min(chargeTime * throwForce, maxForce));
        isCharging = false;
        
        throwLine.enabled = false;
    }

    void ThrowGlass(float force)
    {
        Vector3 spawnPosition = glassMover.position;
        
        GameObject glass = Instantiate(glassPrefab, spawnPosition, throwPosition.rotation);
        
        Rigidbody rb = glass.GetComponent<Rigidbody>();
        
        Vector3 finalThrowDirection = (throwPosition.transform.right + throwDirection).normalized;
        rb.AddForce(finalThrowDirection * force, ForceMode.VelocityChange);
    }

    void ShowTrajectory(Vector3 origin, Vector3 speed)
    {
        Vector3[] points  = new Vector3[100];
        throwLine.positionCount = points.Length;
        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;
            points[i] = origin + speed * time + 0.5f * Physics.gravity * time * time;
        }
        throwLine.SetPositions(points);
    }
}