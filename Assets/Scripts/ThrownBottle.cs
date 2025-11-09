using UnityEngine;

public class ThrownBottle : LaneObstacle
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			
			other.GetComponent<PlayerController>().Die();
		}
	}
}
