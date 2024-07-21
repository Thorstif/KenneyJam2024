using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamerGilbertHandler : MonoBehaviour
{
    public GameObject gilbert1;
    public GameObject gilbert2;
    public GameObject gilbert3;
    
    private void Start()
    {
        if(GameProgressManager.Instance.GetFlag("playedGame"))
        {
            gilbert1.SetActive(false);
            gilbert2.SetActive(false);
            gilbert3.SetActive(true);
        }
        else if(GameProgressManager.Instance.GetFlag("deliveredPizza"))
        {
            gilbert1.SetActive(false);
            gilbert2.SetActive(true);
            gilbert3.SetActive(false);
        }
        else if(GameProgressManager.Instance.GetFlag("fetchPizza"))
        {
            gilbert1.SetActive(true);
            gilbert2.SetActive(false);
            gilbert3.SetActive(false);
        }
    }
}
