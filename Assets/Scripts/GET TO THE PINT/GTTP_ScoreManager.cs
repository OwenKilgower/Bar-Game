using UnityEngine;
using UnityEngine.SceneManagement;

public class GTTP_ScoreManager : MonoBehaviour
{
	[Header("Scene")]
	public string nextScene = "Next Scene fr";

	public void LoadNextScene()
	{
		Debug.Log("[ScoreManager] Loading: " + nextScene);
		SceneManager.LoadScene(nextScene);
	}
}


