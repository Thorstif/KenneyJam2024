using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public Transform characterModel;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Get input for movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Calculate movement vector
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (movement != Vector3.zero)
        {
            // Calculate the angle to rotate towards
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);

            // Smoothly rotate the character model towards the target direction
            characterModel.rotation = Quaternion.Slerp(characterModel.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime);
        }

        // Apply movement using Rigidbody
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}