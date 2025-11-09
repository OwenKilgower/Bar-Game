using UnityEngine;
using System.Collections;
public class LaneObstacleSpawner : MonoBehaviour

{
	public LaneObstacle[] lanePrefabs;
	public float spawnInterval = 2f;
	public float randomness = 0.5f;

	IEnumerator Start()
	{
		while (true)
		{
			Spawn();
			yield return new WaitForSeconds(spawnInterval + Random.Range(-randomness, randomness));
		}
	}

	void Spawn()
	{
		LaneObstacle prefab = lanePrefabs[Random.Range(0, lanePrefabs.Length)];
		Instantiate(prefab, transform.position, Quaternion.identity);
	}
}

