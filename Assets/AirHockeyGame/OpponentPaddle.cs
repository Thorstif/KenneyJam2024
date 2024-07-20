using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentPaddle : MonoBehaviour
{

    public float paddleSpeed = 5f;
    public float puckForce = 10f;

    public GameObject puck;

    // Update is called once per frame
    void Update()
    {
        var targetPosition = new Vector3(puck.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition, paddleSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == puck)
        {
            // Calculate direction from paddle to puck
            Vector3 direction = (puck.transform.position - gameObject.transform.position).normalized;

            // Apply force to the puck
            Rigidbody puckRb = puck.GetComponent<Rigidbody>();
            puckRb.AddForce(direction * puckForce, ForceMode.Impulse);
        }
    }
}
