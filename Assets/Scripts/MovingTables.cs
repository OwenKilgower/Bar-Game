using UnityEngine;

public class MovingTables : LaneObstacle
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			// Attach player to log so they move with it
			other.transform.SetParent(transform);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			// Release the player when leaving log
			other.transform.SetParent(null);
		}
	}
}

