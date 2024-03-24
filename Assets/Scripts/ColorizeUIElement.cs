using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorizeUIElement : MonoBehaviour
{
    // Start is called before the first frame update
    public RawImage image;
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;
    void Start()
    {
        image.color = new Color(1, 0, 0, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        image.color = new Color(redSlider.value, greenSlider.value, blueSlider.value, 1.0f);
    }
}
