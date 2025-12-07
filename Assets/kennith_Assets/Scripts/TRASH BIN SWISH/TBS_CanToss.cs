using UnityEngine;

public class TBS_CanToss: MonoBehaviour
{
    private Rigidbody rb;
    private bool isDragging = false;
    private Vector3 dragStartPos;

    [Header("Throw Settings")]
    public float throwForce = 0.05f;
    public float followSpeed = 10f; // how fast it follows the mouse
    public float upwardBoost = 1f;  // adds an arc
    public float spinForce = 1f;    // strength of random spin

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Freeze physics at spawn
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    void OnMouseDown()
    {
        if (TBS_GameManager.Instance.currentCan != gameObject)
            return;

        isDragging = true;

        // Freeze physics while dragging
        rb.isKinematic = true;
        rb.useGravity = false;

        dragStartPos = Input.mousePosition;
    }

    void Update()
    {
        if (!isDragging) return;

        // Follow the mouse cursor
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;

        Vector3 targetPos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);

        // Release to throw
        if (Input.GetMouseButtonUp(0))
        {
            Throw();
        }
    }

    void Throw()
    {
        isDragging = false;

        Vector3 dragEndPos = Input.mousePosition;
        Vector3 dragDelta = dragStartPos - dragEndPos;

        rb.isKinematic = false;
        rb.useGravity = true;

        // Convert drag to 3D direction relative to camera
        Vector3 throwDir = new Vector3(-dragDelta.x, upwardBoost, -dragDelta.y);

        rb.AddForce(Camera.main.transform.TransformDirection(throwDir) * throwForce, ForceMode.Impulse);

        // Add random spin
        Vector3 randomTorque = new Vector3(
            Random.Range(-spinForce, spinForce),
            Random.Range(-spinForce, spinForce),
            Random.Range(-spinForce, spinForce)
        );
        rb.AddTorque(randomTorque, ForceMode.Impulse);

        // Notify GameManager
        TBS_GameManager.Instance.OnCanToss();
    }
}





