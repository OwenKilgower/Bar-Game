using UnityEngine;

public class GTTP_GameManager : MonoBehaviour
{
	public static GTTP_GameManager Instance;
	public GTTP_PlayerControls player;
	

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
		
		Debug.Log("Goal Reached! Score:");
		
		GameOver();
	}

	void GameOver()
	{
		Debug.Log("GAME OVER!");
	}
}

