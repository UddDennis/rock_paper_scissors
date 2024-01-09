using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuController : MonoBehaviour
{
    public void StartGame()
    {
        // Scene currentScene = SceneManager.GetActiveScene();

        // // Unload the current scene asynchronously
        // SceneManager.UnloadSceneAsync(currentScene);
        Slider slider = SliderManager.instance.slider;
        if (slider != null)
        {
            PlayerPrefs.SetInt("NumberOfBalls", (int)slider.value);
            PlayerPrefs.Save();
        }
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        // SceneManager.UnloadSceneAsync("MenuScene");
    }
}
