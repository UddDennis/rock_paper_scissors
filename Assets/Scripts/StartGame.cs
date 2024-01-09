using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void Start()
    {
        SceneManager.LoadScene("MenuScene",  LoadSceneMode.Single);
    }
}