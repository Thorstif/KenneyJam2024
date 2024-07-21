using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgressManager : MonoBehaviour
{
    public static GameProgressManager Instance { get; private set; }

    private Dictionary<string, bool> progressFlags = new Dictionary<string, bool>();

    private void Awake()
    {
        // Singleton pattern implementation
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void SetFlag(string flag, bool value)
    {
        progressFlags[flag] = value;
    }

    public bool GetFlag(string flag)
    {
        return progressFlags.TryGetValue(flag, out bool value) ? value : false;
    }
}

// public enum ProgressFlag
// {
//     TalkedToFrank,
//     ExitedLostWoods,
//     DeliveredPizza
// }
