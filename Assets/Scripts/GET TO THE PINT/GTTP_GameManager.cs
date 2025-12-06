using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GTTP_GameManager : MonoBehaviour
{
	public static GTTP_GameManager Instance;

	public GTTP_PlayerControls player;

	[Header("UI Images")]
	public GameObject goalImage;
	public GameObject gameOverImage;

	[Header("Scene Settings")]
	public string nextScene;         // scene after goal
	public string gameOverScene;     // scene after losing

	[Header("Display Settings")]
	public float displayDuration = 2f; // how long image shows before switching

	void Awake()
	{
		if (Instance == null) Instance = this;
		else Destroy(gameObject);
	}

	public void PlayerDied()
	{
		Debug.Log("Player Died! Lives left: " + player.lives);

		if (player.lives <= 0)
			StartCoroutine(ShowImageAndLoadScene(gameOverImage, gameOverScene));
	}

	public void PlayerReachedGoal()
	{
		Debug.Log("Goal Reached!");
		StartCoroutine(ShowImageAndLoadScene(goalImage, nextScene));
	}

	private IEnumerator ShowImageAndLoadScene(GameObject imageObject, string sceneName)
	{
		imageObject.SetActive(true);            // show PNG image
		Time.timeScale = 0f;                    // freeze gameplay
		yield return new WaitForSecondsRealtime(displayDuration); // wait while paused
		Time.timeScale = 1f;                    // unfreeze before switching scene
		SceneManager.LoadScene(sceneName);      // change scene
	}
}



