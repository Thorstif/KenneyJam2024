using System.Threading;
using UnityEngine;

public class AirHockeyRules : MonoBehaviour
{
    float timer = 0;

    public float gameEndTimer = 60;
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
        timer += Time.deltaTime;

        if(timer > gameEndTimer)
        {
            //game end TODO
        }
    }

    void CheckIfPuckIsOutOfBounds()
    {
        if (puck.transform.localPosition.z < -0.235f || puck.transform.localPosition.z > 0.235f)
        {
            ResetPuck();
        }
        else if (puck.transform.localPosition.x < -0.385f || puck.transform.localPosition.x > 0.385f)
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
