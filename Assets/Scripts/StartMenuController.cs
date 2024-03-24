using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuController : MonoBehaviour
{
    public RawImage paper;
    public RawImage rock;
    public RawImage scissor;
    public RawImage background;

    public void StartGame()
    {
        Slider slider = SliderManager.instance.slider;
        if (slider != null)
        {
            GameManager.Instance.NumberOfBalls = (int)slider.value;
        }
        GameManager.Instance.PaperColor = paper.color;
        GameManager.Instance.RockColor = rock.color;
        GameManager.Instance.ScissorColor = scissor.color;
        GameManager.Instance.BackgroundColor = background.color;


        SceneLoader.Instance.SwitchScene("GameScene");
    }
}
