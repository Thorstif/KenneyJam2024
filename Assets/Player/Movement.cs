using UnityEngine;

public class Movement : MonoBehaviour
{
   public float moveSpeed = 5f;
   public float rotationSpeed = 10f;
   public Transform characterModel;
    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement,Vector3.up);

            characterModel.rotation = Quaternion.Slerp(characterModel.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        transform.Translate(movement * moveSpeed * Time.deltaTime,Space.World);
    }
}
