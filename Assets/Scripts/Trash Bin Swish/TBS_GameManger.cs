using UnityEngine;

public class TBS_GameManager : MonoBehaviour
{
	public static TBS_GameManager Instance;

	[Header("Attempts")]
	public int maxAttempts = 3;
	private int remainingAttempts;

	[Header("Spawning")]
	public GameObject canPrefab;
	public Transform spawnPoint;

	[HideInInspector]
	public GameObject currentCan;

	void Awake()
	{
		// Set singleton
		if (Instance == null)
			Instance = this;
		else
			Destroy(gameObject);
	}

	void Start()
	{
		remainingAttempts = maxAttempts;
	}

	void Update()
	{
		// Spawn new can when clicking anywhere IF:
		// - No can currently exists
		// - Still have attempts left
		if (Input.GetMouseButtonDown(0) && currentCan == null && remainingAttempts > 0)
		{
			SpawnNewCan();
		}
	}

	void SpawnNewCan()
	{
		currentCan = Instantiate(canPrefab, spawnPoint.position, spawnPoint.rotation);
	}

	public void OnCanToss()
	{
		remainingAttempts--;
		currentCan = null;

		Debug.Log("Can tossed! Attempts left: " + remainingAttempts);
	}
}

