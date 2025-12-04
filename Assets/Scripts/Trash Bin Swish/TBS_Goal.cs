using UnityEngine;

public class TBS_Goal : TBS_ScoreManager
{
	public void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<TBS_CanToss>() != null)
		{
			Debug.Log("SCORED!");

			goalscored();

		}
	}
}


