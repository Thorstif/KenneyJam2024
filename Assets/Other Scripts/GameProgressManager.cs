using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgressManager : MonoBehaviour
{
    public static GameProgressManager Instance { get; private set; }

    private Dictionary<ProgressFlag, bool> progressFlags = new Dictionary<ProgressFlag, bool>();

    private void Awake()
    {
        // Singleton pattern implementation
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeFlags();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeFlags()
    {
        // Initialize all flags to false
        foreach (ProgressFlag flag in System.Enum.GetValues(typeof(ProgressFlag)))
        {
            progressFlags[flag] = false;
        }
    }

    public void SetFlag(ProgressFlag flag, bool value)
    {
        progressFlags[flag] = value;
    }

    public bool GetFlag(ProgressFlag flag)
    {
        return progressFlags.TryGetValue(flag, out bool value) ? value : false;
    }
}

public enum ProgressFlag
{
    TalkedToFrank,
    ExitedLostWoods,
    DeliveredPizza
}
