using UnityEngine;

public class GTTP_ThrownBottle : GTTP_LaneObstacle
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			
			other.GetComponent<GTTP_PlayerControls>().Die();
		}
	}
}
