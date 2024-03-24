using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundColorSetter : MonoBehaviour
{
    private SpriteRenderer backgroundSpriteRenderer;

    void Start()
    {
        backgroundSpriteRenderer = GetComponent<SpriteRenderer>();        
        backgroundSpriteRenderer.color = GameManager.Instance.BackgroundColor;
    }
}