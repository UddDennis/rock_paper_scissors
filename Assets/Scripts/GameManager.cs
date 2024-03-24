using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public Color PaperColor;
    public Color RockColor;
    public Color ScissorColor;
    public Color BackgroundColor;
    public int NumberOfBalls;
    // Start is called before the first frame update
    void Start()
    {
        PaperColor = new Color(1, 0, 0, 1.0f);
        RockColor = new Color(0, 1, 0, 1.0f);
        ScissorColor = new Color(0, 0, 1, 1.0f); 
        BackgroundColor = new Color(0, 0, 0, 1.0f);
    }

    // Singleton instance property
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("GameManager");
                    instance = singletonObject.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }
}
