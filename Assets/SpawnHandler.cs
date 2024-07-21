using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    public GameObject lostWods;
    public GameObject arcade;
    void Start()
    {
        if(GameProgressManager.Instance.GetFlag("exitedLostWoods"))
        {
            GameProgressManager.Instance.SetFlag("ExitedLostWoods", false);
            var player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = lostWods.transform.position;
        }
        else if(GameProgressManager.Instance.GetFlag("exitedArcade"))
        {
            GameProgressManager.Instance.SetFlag("exitedArcade", false);
            var player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = arcade.transform.position;
        }
    }

    // Update is called once per frame
}
