using UnityEngine;

public class GTTP_UiControls : MonoBehaviour
{
	public GameObject controlsText; 

	void Update()
	{
		// Check if any of the movement keys are pressed
		if (Input.GetKeyDown(KeyCode.W) ||
		    Input.GetKeyDown(KeyCode.S) ||
		    Input.GetKeyDown(KeyCode.A) ||
		    Input.GetKeyDown(KeyCode.D))
		{
			controlsText.SetActive(false); 
		}
	}
}
