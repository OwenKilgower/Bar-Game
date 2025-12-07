using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseClamp : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Clamp"))
        {
            Debug.Log("Clamp entered");
            source.PlayOneShot(clip);
            Destroy(gameObject, 0.5f);
        }
    }
}
