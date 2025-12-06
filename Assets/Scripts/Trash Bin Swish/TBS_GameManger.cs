using UnityEngine;

public class TBS_GameManager : MonoBehaviour
{
	public static TBS_GameManager Instance;

	[Header("Attempts")]
	public int maxAttempts = 5;
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

		if (remainingAttempts <= 0)
		{
			TBS_ScoreManager.Instance.OutOfAttempts();
		}
	}
	
}

