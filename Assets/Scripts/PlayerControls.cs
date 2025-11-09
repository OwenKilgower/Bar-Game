using UnityEngine;

public class PlayerControls : CharacterBase
{
	[Header("Movement Settings")]
	public float hopDistance = 1f;
	public float moveSpeed = 6f;

	[Header("Keybinds")]
	public KeyCode moveUp = KeyCode.W;
	public KeyCode moveDown = KeyCode.S;
	public KeyCode moveLeft = KeyCode.A;
	public KeyCode moveRight = KeyCode.D;

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
		PerformMovement();
	}

	void HandleInput()
	{
		if (isMoving) return;

		Vector3 dir = Vector3.zero;

		if (Input.GetKeyDown(moveUp)) dir = Vector3.forward;
		else if (Input.GetKeyDown(moveDown)) dir = Vector3.back;
		else if (Input.GetKeyDown(moveLeft)) dir = Vector3.left;
		else if (Input.GetKeyDown(moveRight)) dir = Vector3.right;

		if (dir != Vector3.zero)
		{
			targetPos = transform.position + dir * hopDistance;
			isMoving = true;
		}
	}

	void PerformMovement()
	{
		if (!isMoving) return;

		transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

		if (Vector3.Distance(transform.position, targetPos) < 0.001f)
			isMoving = false;
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
		// Use CharacterBase death behavior
		base.Die();
	}
}


