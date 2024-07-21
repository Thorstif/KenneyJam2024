using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PuckGoal : MonoBehaviour
{
    public GameObject puck;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == puck)
        {
            GameProgressManager.Instance.SetFlag("playedGame", true);
            GameSceneManager.Instance.LoadScene("Arcade inside");
        }
    }
}
