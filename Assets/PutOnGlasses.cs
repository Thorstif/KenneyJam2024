using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutOnGlasses : MonoBehaviour
{
    public GameObject glasses;
    // Start is called before the first frame update
    void Start()
    {
        if(GameProgressManager.Instance.GetFlag("talkedToCoolGuy"))
        {
            glasses.SetActive(true);
        }
    }
}
