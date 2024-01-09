using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemSpawner : MonoBehaviour
{
     public GameObject blackPrefab; // Prefab for black items
    public GameObject redPrefab; // Prefab for red items
    public GameObject bluePrefab; // Prefab for blue items
    public GameObject gameArea;
    public int numberOfItems = 9; // Total number of items to spawn (divisible by 3 for equal distribution)


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

     private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
            GameObject eventSystem = GameObject.Find("EventSystem_" + scene.name);
            if (eventSystem != null)
            {
                Debug.Log("Enable eventsystem: " + eventSystem);
                eventSystem.SetActive(true); // Activate the Event System in the loaded scene
                // GameObject.Find("EventSystem_MenuScene").SetActive(false);
            }
            // Instantiate objects or perform actions specific to this scene
            if (scene.name == "GameScene") {
                Debug.Log("GHJAJHGDHJKHJADGJHAGDHKJAGDHKJAGDHKJ");
                SpawnItems();
            }
    
    }
    // void Start()
    // {
    //     if (SceneManager.GetActiveScene().name == "GameScene") {
    //         SpawnItems();
    //     }
    // }
    void Awake()
    {
        GameObject eventSystem = GameObject.Find("EventSystem_GameScene");
        if (eventSystem.activeSelf == false) {
            SceneManager.LoadScene(0);
        }
    }

    void SpawnItems()
    {    
        int hej = PlayerPrefs.GetInt("NumberOfBalls");
        Debug.Log(hej);
        int itemsPerType = hej / 3; // Number of items for each color

        for (int i = 0; i < itemsPerType; i++)
        {
            // Spawn black items
            InstantiateItem(blackPrefab);

            // Spawn red items
            InstantiateItem(redPrefab);

            // Spawn blue items
            InstantiateItem(bluePrefab);
        }
    }

    void InstantiateItem(GameObject prefab)
    {
        // Generate random position within the view
        Camera mainCamera = Camera.main;

        // Define the viewport boundaries (e.g., 0 to 1 in X and Y axes)
        float minX = mainCamera.ViewportToWorldPoint(new Vector3(0.1f, 0, 0)).x;
        float maxX = mainCamera.ViewportToWorldPoint(new Vector3(0.9f, 0, 0)).x;
        float minY = mainCamera.ViewportToWorldPoint(new Vector3(0, 0.1f, 0)).y;
        float maxY = mainCamera.ViewportToWorldPoint(new Vector3(0, 0.9f, 0)).y;

        // Generate random position within the calculated viewport boundaries
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);
        // Vector3 randomPosition = new Vector3(Random.Range(2f, 10f), Random.Range(2f, 10f), 0f);

        // Instantiate the prefab at the random position
        GameObject newItem = Instantiate(prefab, randomPosition, Quaternion.identity);
    }
}
