using UnityEngine;

public class GTTP_CharacterBase : MonoBehaviour

{
	public int lives = 3;
	protected Vector3 startPosition;

	protected virtual void Start()
	{
		startPosition = transform.position;
	}

	public virtual void Die()
	{
		lives--;
		GTTP_GameManager.Instance.PlayerDied();
		Respawn();
	}

	public virtual void Respawn()
	{
		transform.SetParent(null);
		transform.position = startPosition;
	}
}


