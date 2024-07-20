using UnityEngine;

public class AirHockeyController : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject paddle;
    public GameObject puck;
    public BoxCollider boardCollider;

    public float paddleSpeed = 10f;
    public float puckForce = 10f;

    private Vector3 boardMin;
    private Vector3 boardMax;

    void Start()
    {
        // Calculate board boundaries
        boardMin = boardCollider.bounds.min;
        boardMax = boardCollider.bounds.max;
    }

    void Update()
    {
        MovePaddle();
    }

    void MovePaddle()
    {
        // Get mouse position in world space
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, paddle.transform.position);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 targetPosition = ray.GetPoint(rayDistance);

            // Restrict paddle movement within board boundaries
            targetPosition.x = Mathf.Clamp(targetPosition.x, boardMin.x, boardMax.x);
            targetPosition.z = Mathf.Clamp(targetPosition.z, boardMin.z, boardMax.z);

            // Move paddle towards target position
            paddle.transform.position = Vector3.MoveTowards(paddle.transform.position, targetPosition, paddleSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == puck)
        {
            // Calculate direction from paddle to puck
            Vector3 direction = (puck.transform.position - paddle.transform.position).normalized;

            // Apply force to the puck
            Rigidbody puckRb = puck.GetComponent<Rigidbody>();
            puckRb.AddForce(direction * puckForce, ForceMode.Impulse);
        }
    }
}