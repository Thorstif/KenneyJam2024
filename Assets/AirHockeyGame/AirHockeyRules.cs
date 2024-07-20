using UnityEngine;

public class AirHockeyRules : MonoBehaviour
{
    public GameObject puck;

    private Vector3 startingPosition;

    private Rigidbody puckRb;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = puck.transform.localPosition;
        puckRb = puck.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfPuckIsOutOfBounds();
    }

    void CheckIfPuckIsOutOfBounds()
    {
        if (puck.transform.localPosition.z < -0.25f || puck.transform.localPosition.z > 0.25f)
        {
            ResetPuck();
        }
        else if (puck.transform.localPosition.x < -15f || puck.transform.localPosition.x > 15f)
        {
            ResetPuck();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        ResetPuck();
    }

    private void ResetPuck()
    {
        puck.transform.localPosition = startingPosition;
        puckRb.velocity = Vector3.zero;
    }

    
}
