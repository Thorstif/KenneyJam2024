
using UnityEngine;

public class PuckTableBounceScript : MonoBehaviour
{

    public GameObject long1;
    public GameObject long2;
    public GameObject short1;
    public GameObject short2;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == long1 || collision.gameObject == long2 || collision.gameObject == short1 || collision.gameObject == short2)
        {
             // Get the collision normal
            Vector3 normal = collision.contacts[0].normal;

            // Calculate reflection vector
            Vector3 reflectedVelocity = Vector3.Reflect(rb.velocity, normal);

            // Apply the reflected velocity
            //rb.velocity = reflectedVelocity;

            rb.AddForce(reflectedVelocity.normalized * 1.75f, ForceMode.Impulse);
        }
    }
}
