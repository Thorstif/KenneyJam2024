using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeSpawnManager : MonoBehaviour
{
    public GameObject otherSpawn;
    // Start is called before the first frame update
    void Start()
    {
        if(GameProgressManager.Instance.GetFlag("playedGame"))
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = otherSpawn.transform.position;
        }
    }
}
