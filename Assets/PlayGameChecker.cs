
using UnityEngine;

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
