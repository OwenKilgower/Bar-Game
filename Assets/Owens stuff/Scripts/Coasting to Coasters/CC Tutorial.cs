using UnityEngine;

public class CCTutorial : MonoBehaviour
{
    public GameObject controlsText; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // 0 = left mouse button
        {
            controlsText.SetActive(false); // hide the controls text
        }
    }
}
