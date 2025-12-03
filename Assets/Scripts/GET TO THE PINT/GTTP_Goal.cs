using UnityEngine;

public class GTTP_Goal : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
			GTTP_GameManager.Instance.PlayerReachedGoal();
	}
}


