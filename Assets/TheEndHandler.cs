using UnityEngine;

public class TheEndHandler : MonoBehaviour
{
    void Update()
    {
        if(GameProgressManager.Instance.GetFlag("gameEnd"))
        {
            GameSceneManager.Instance.LoadScene("The end");
        }
    }
}
