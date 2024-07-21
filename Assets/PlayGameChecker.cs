using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGameChecker : MonoBehaviour
{
    void Update()
    {
        if(GameProgressManager.Instance.GetFlag("playGame"))
        {
            GameSceneManager.Instance.LoadScene("AirHockeyGame");
            GameProgressManager.Instance.SetFlag("playGame", false);
        }
    }
}
