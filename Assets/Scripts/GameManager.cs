using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
	public PlayerControls player;
	public int score = 0;

	void Awake()
	{
		if (Instance == null) Instance = this;
		else Destroy(gameObject);
	}

	public void PlayerDied()
	{
		Debug.Log("Player Died! Lives left: " + player.lives);

		if (player.lives <= 0)
			GameOver();
	}

	public void PlayerReachedGoal()
	{
		score += 100;
		Debug.Log("Goal Reached! Score: " + score);
	}

	void GameOver()
	{
		Debug.Log("GAME OVER!");
	}
}

