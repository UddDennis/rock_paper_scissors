using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RandomMovement : MonoBehaviour
{
    public float moveSpeed = 1f; // Speed of movement
    Slider slider; 
    private Vector3 randomDirection; 

    public SpriteRenderer spriteRenderer;
    
    void Start()
    {
        slider = SliderManager.instance.slider;
        // Initialize the first random direction
        ChangeDirection();
        
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        
        if (slider != null)
        {
            moveSpeed = slider.value;
        }
        transform.Translate(randomDirection * moveSpeed * Time.deltaTime * Random.Range(0.5f, 0.8f));

    }

    void ChangeDirection()
    {
        // Generate a new random direction
        randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 newDirection = Vector2.Reflect(randomDirection, collision.contacts[0].normal);
        randomDirection = newDirection;

        if (gameObject.tag == "Scissor" && collision.gameObject.CompareTag("Rock")) {
            spriteRenderer.color = new Color(1, 0, 0, 1.0f);
            gameObject.tag = "Rock";
        }
        if (gameObject.tag == "Rock" && collision.gameObject.CompareTag("Paper")) {
            spriteRenderer.color = new Color(0, 1, 0, 1.0f);
            gameObject.tag = "Paper";
        }
        if (gameObject.tag == "Paper" && collision.gameObject.CompareTag("Scissor")) {
            spriteRenderer.color = new Color(0, 0, 1, 1.0f);
            gameObject.tag = "Scissor";
        }
    }

    void OnMouseDown()
    {
        Debug.Log("Object Clicked: " + gameObject.name);
        ChangeDirection();
        // Perform actions when the object is clicked
        // For example, you could change its color, scale, or perform any desired action.


        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            // Change the color of the object's material
            renderer.material.color = new Color(Random.value, Random.value, Random.value, 1.0f);
        }
    }
}
