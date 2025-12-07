using UnityEngine;

public abstract class TBS_ThrowObject : MonoBehaviour
{
	protected Rigidbody rb;
	protected Camera cam;

	protected Vector3 dragStartPos;
	protected Vector3 dragEndPos;

	protected bool isHeld = false;

	public float throwForce = 5f;
	public float upwardBoost = 2f;

	protected virtual void Awake()
	{
		rb = GetComponent<Rigidbody>();
		cam = Camera.main;
	}

	public virtual void BeginHold()
	{
		isHeld = true;
		rb.isKinematic = true;  // freezes until released
		dragStartPos = Input.mousePosition;
	}

	protected virtual void Update()
	{
		if (!isHeld) return;

		// Waiting for release
		if (Input.GetMouseButtonUp(0))
		{
			dragEndPos = Input.mousePosition;
			ReleaseAndThrow();
		}
	}

	protected virtual void ReleaseAndThrow()
	{
		isHeld = false;
		rb.isKinematic = false;
		Throw();
	}

	protected virtual void Throw()
	{
		Vector3 drag = dragEndPos - dragStartPos;

		Vector3 direction = new Vector3(
			drag.x,
			drag.y + upwardBoost,
			drag.y
		);

		rb.AddForce(cam.transform.TransformDirection(direction) * throwForce,
			ForceMode.Impulse);
	}
}



