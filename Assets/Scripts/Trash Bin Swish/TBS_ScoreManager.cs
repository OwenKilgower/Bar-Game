using UnityEngine;
using System.Collections;  
using UnityEngine.SceneManagement;

public class TBS_ScoreManager : MonoBehaviour
{
	public static TBS_ScoreManager Instance { get; private set; }

	[Header("Score")]
	public int score = 0;
	public int scoreTarget = 3;

	[Header("Scene")]
	[SerializeField] public string nextScene = "Next Scene fr";

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}
		Instance = this;
		
	}

	
	public void GoalScored()
	{
		score += 1;
		Debug.Log("[ScoreManager] score: " + score);

		if (score >= scoreTarget)
		{
			OnTargetReached();
		}
	}

	private void OnTargetReached()
	{
		Debug.Log("[ScoreManager] target reached, loading: " + nextScene);
		// Make sure nextScene exists in Build Settings
		SceneManager.LoadScene(nextScene);
	}
	
	public void OutOfAttempts()
	{
		Debug.Log("[ScoreManager] Out of attempts — changing scene soon...");

		// Delay scene change
		StartCoroutine(DelayedSceneLoad());
	}

	private IEnumerator DelayedSceneLoad()
	{
		yield return new WaitForSeconds(2f);  

		SceneManager.LoadScene(nextScene);
	}
}