using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
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

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // This method will be called whenever a scene finishes loading
        Debug.Log("Scene loaded: " + scene.name);

        // Check the name of the loaded scene and handle Event Systems or other tasks as needed
        // if (scene.name == "YourSceneName")
        // {
        GameObject eventSystem = GameObject.Find("EventSystem_" + scene.name);
        if (eventSystem != null)
        {
            Debug.Log("Enable eventsystem: " + eventSystem);
            eventSystem.SetActive(true); // Activate the Event System in the loaded scene
        }

        
        // }
    }
    private void OnSceneUnloaded(Scene scene)
    {
        // This method will be called whenever a scene finishes loading
        Debug.Log("Scene unloaded: " + scene.name);

        // Check the name of the loaded scene and handle Event Systems or other tasks as needed
        // if (scene.name == "YourSceneName")
        // {
        GameObject eventSystem = GameObject.Find("EventSystem_" + scene.name);
        if (eventSystem != null)
        {
            Debug.Log("Disable eventsystem: " + eventSystem);
            eventSystem.SetActive(false); // Activate the Event System in the loaded scene
        }
        // }
    }
}