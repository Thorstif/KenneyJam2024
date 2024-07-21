using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    // Singleton instance
    public static GameSceneManager Instance { get; private set; }

    // Public readonly strings for scene names
    public readonly string TesteScene = "TesteScene";
    public readonly string LostWoods = "Lost Woods";
    public readonly string Arcade = "Arcade";
    // Add more scene names as needed

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

    // Load a scene by name
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Get the current scene name
    public string GetCurrentSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    // Check if a scene is loaded
    public bool IsSceneLoaded(string sceneName)
    {
        return SceneManager.GetSceneByName(sceneName).isLoaded;
    }

    // Reload the current scene
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Load the next scene (assuming scenes are in build settings in order)
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);
    }
}