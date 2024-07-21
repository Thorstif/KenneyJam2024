using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkFrankHandler : MonoBehaviour
{
    public GameObject frank1;
    public GameObject frank2;

    private void Start()
    {
        if (GameProgressManager.Instance.GetFlag("deliveredPizza"))
        {
            frank1.SetActive(false);
            frank2.SetActive(false);
        }
        else if(GameProgressManager.Instance.GetFlag("gotPizza"))
        {
            frank1.SetActive(false);
            frank2.SetActive(true);
        }
    }
}
