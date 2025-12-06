using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class TBS_ScoreManager : MonoBehaviour
{
	public static TBS_ScoreManager Instance { get; private set; }

	[Header("Score")]
	public int score = 0;
	public int scoreTarget = 3;

	[Header("UI Images")]
	public GameObject goalCompleteUI;
	public GameObject goalFailedUI;

	[Header("Scene")]
	public string nextScene = "Next Scene fr";

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}
		Instance = this;
	}

	// When scoring a goal
	public void GoalScored()
	{
		score++;
		Debug.Log("[ScoreManager] score: " + score);

		if (score >= scoreTarget)
		{
			StartCoroutine(ShowGoalComplete());
		}
	}

	// When out of attempts
	public void OutOfAttempts()
	{
		Debug.Log("[ScoreManager] Out of attempts — showing fail UI...");

		StartCoroutine(ShowGoalFailed());
	}

	private IEnumerator ShowGoalComplete()
	{
		Debug.Log("[ScoreManager] showing goal complete UI...");
        
		if (goalCompleteUI != null)
			goalCompleteUI.SetActive(true);

		yield return new WaitForSeconds(2f);

		SceneManager.LoadScene(nextScene);
	}

	private IEnumerator ShowGoalFailed()
	{
		Debug.Log("[ScoreManager] showing goal failed UI...");

		if (goalFailedUI != null)
			goalFailedUI.SetActive(true);

		yield return new WaitForSeconds(2f);

		SceneManager.LoadScene(nextScene);
	}
}