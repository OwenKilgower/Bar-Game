using UnityEngine;

public class TBS_Goal : MonoBehaviour
{
	
	public string acceptedTag = ""; 

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("[Goal] Trigger entered by: " + other.name);

		if (!string.IsNullOrEmpty(acceptedTag))
		{
			if (other.CompareTag(acceptedTag))
			{
				Debug.Log("[Goal] Tag matched: " + acceptedTag);
				TBS_ScoreManager.Instance?.GoalScored();
			}
			return;
		}

		
		if (other.GetComponent<TBS_CanToss>() != null)
		{
			Debug.Log("[Goal] Can detected, scoring...");
			TBS_ScoreManager.Instance?.GoalScored();
			
		}
	}
}



