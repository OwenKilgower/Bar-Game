using UnityEngine;

public class TBS_Goal : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<TBS_CanToss>() != null)
		{
			Debug.Log("SCORED!");
		}
	}
}


