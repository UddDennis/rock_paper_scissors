using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private string currentSceneName;

    private static SceneLoader instance;

    public static SceneLoader Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SceneLoader>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("SceneLoader");
                    instance = singletonObject.AddComponent<SceneLoader>();
                }
            }
            return instance;
        }
    }
    private void Start()
    {
        LoadSceneAdditive("MenuScene");
        currentSceneName = "MenuScene";
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
        
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    public void SwitchScene(string newSceneName)
    {
        // Unload the current scene
        UnloadScene(currentSceneName);

        // Load the new scene additively
        LoadSceneAdditive(newSceneName);

        // Update the current scene name
        currentSceneName = newSceneName;
    }

    private void LoadSceneAdditive(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    private void UnloadScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene loaded: " + scene.name);
    }
    private void OnSceneUnloaded(Scene scene)
    {
        Debug.Log("Scene unloaded: " + scene.name);
    }
}