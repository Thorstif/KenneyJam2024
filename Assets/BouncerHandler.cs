using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerHandler : MonoBehaviour
{
    public GameObject bouncer1;
    public GameObject bouncer2;
    private void Start()
    {
        if(GameProgressManager.Instance.GetFlag("talkedToCoolGuy"))
        {
            bouncer1.SetActive(false);
            bouncer2.SetActive(true);
        }
    }
}
