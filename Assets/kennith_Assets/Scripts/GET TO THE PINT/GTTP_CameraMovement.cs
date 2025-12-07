using UnityEngine;

public class GTTP_CameraFollow : MonoBehaviour
{
	public Transform target;    // The player
	public Vector3 offset;      // Distance from player
	public float followSpeed = 5f;

	void LateUpdate()
	{
		if (target == null) return;

		Vector3 desiredPos = target.position + offset;
		transform.position = Vector3.Lerp(transform.position, desiredPos, followSpeed * Time.deltaTime);
	}
}


