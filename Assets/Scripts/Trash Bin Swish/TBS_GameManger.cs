using UnityEngine;
using System.Collections; 

public class TBS_GameManager : MonoBehaviour
{
	public static TBS_GameManager Instance;

	[Header("Attempts")]
	public int maxAttempts = 5;
	private int remainingAttempts;

	[Header("Spawning")]
	public GameObject canPrefab;
	public Transform spawnPoint;
	
	public bool waitingForCanToSettle = false;
	public float minWaitBeforeEvaluate = 1.5f; // always wait at least this long
	public float settleVelocity = 0.15f;       // lower threshold
	public float maxSettleTime = 12f;          // timeout
	
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
		waitingForCanToSettle = true;

		Debug.Log("Can tossed! Attempts left: " + remainingAttempts);

		// Start watching the can until it stops
		StartCoroutine(WaitForCanToSettle(currentCan.GetComponent<Rigidbody>()));

		
	}
	
	private IEnumerator WaitForCanToSettle(Rigidbody canRb)
	{
		float startTime = Time.time;

		// Always wait at least a minimum time after a throw
		while (Time.time - startTime < minWaitBeforeEvaluate)
			yield return null;

		// After minimum wait, THEN begin checking velocity
		while (canRb != null && canRb.linearVelocity.magnitude > settleVelocity)
		{
			// safety timeout
			if (Time.time - startTime > maxSettleTime)
			{
				Debug.LogWarning("Settle timeout reached.");
				break;
			}

			yield return null;
		}

		
		yield return new WaitForSeconds(0.3f);

		currentCan = null;

		if (remainingAttempts <= 0 &&
		    TBS_ScoreManager.Instance.score < TBS_ScoreManager.Instance.scoreTarget)
		{
			TBS_ScoreManager.Instance.OutOfAttempts();
		}
	}


	
}

