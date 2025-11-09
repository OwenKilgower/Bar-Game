using UnityEngine;

public class LaneObstacle : MonoBehaviour
{
	public float speed = 5f;
	public Vector3 direction = Vector3.forward;
	public float destroyDistance = 60f;

	private Vector3 spawnPos;

	protected virtual void Start()
	{
		spawnPos = transform.position;
	}

	protected virtual void Update()
	{
		// Shared movement behavior
		transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

		// Shared destroy behavior
		if (Vector3.Distance(spawnPos, transform.position) > destroyDistance)
		{
			Destroy(gameObject);
		}
	}
}
