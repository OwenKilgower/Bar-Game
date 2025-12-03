using UnityEngine;
using System.Collections;
public class GTTP_LaneObstacleSpawner : MonoBehaviour
{
	
	[Header("Spawnable Prefabs")]
	public GTTP_LaneObstacle[] prefabs; 

	[Header("Spawn Settings")]
	public float spawnInterval = 2f;
	public float spawnIntervalRandomness = 0.5f;

	[Header("Movement Settings")]
	public Vector3 spawnDirection = Vector3.right;
	public float laneSpeed = 5f;
	public float spawnOffset = 0f;

	void Start()
	{
		StartCoroutine(SpawnLoop());
	}

	IEnumerator SpawnLoop()
	{
		while (true)
		{
			SpawnObject();
			float wait = spawnInterval + Random.Range(-spawnIntervalRandomness, spawnIntervalRandomness);
			yield return new WaitForSeconds(Mathf.Max(0.2f, wait));
		}
	}

	void SpawnObject()
	{
		if (prefabs == null || prefabs.Length == 0) return;

		GTTP_LaneObstacle prefab = prefabs[Random.Range(0, prefabs.Length)];

		Vector3 spawnPos = transform.position + spawnDirection.normalized * spawnOffset;
		GTTP_LaneObstacle obj = Instantiate(prefab, spawnPos, Quaternion.identity);

		obj.speed = laneSpeed;
		obj.direction = spawnDirection;
	}
}



