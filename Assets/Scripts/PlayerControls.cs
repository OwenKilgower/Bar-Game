using UnityEngine;

public class PlayerControls : MonoBehaviour
{
	public float hopDistance = 1f;
	public float moveSpeed = 6f;

	private bool isMoving = false;
	private Vector3 targetPos;

	protected override void Start()
	{
		base.Start();
		targetPos = transform.position;
	}

	void Update()
	{
		HandleInput();

		if (isMoving)
		{
			transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

			if (Vector3.Distance(transform.position, targetPos) < 0.001f)
				isMoving = false;
		}
	}

	void HandleInput()
	{
		if (isMoving) return;

		Vector3 dir = Vector3.zero;

		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) dir = Vector3.forward;
		else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) dir = Vector3.back;
		else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) dir = Vector3.left;
		else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) dir = Vector3.right;

		if (dir != Vector3.zero)
		{
			targetPos = transform.position + dir * hopDistance;
			isMoving = true;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Goal"))
		{
			GameManager.Instance.PlayerReachedGoal();
			Respawn();
		}
	}

	public override void Die()
	{
		base.Die(); 
	}
}

