using UnityEngine;

public class TBS_UiControls : MonoBehaviour
{
	public GameObject controlsText; 

	void Update()
	{
		if (Input.GetMouseButtonDown(0)) // 0 = left mouse button
		{
			controlsText.SetActive(false); // hide the controls text
		}
	}
}


