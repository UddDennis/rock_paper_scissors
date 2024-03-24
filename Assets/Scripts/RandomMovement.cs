using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RandomMovement : MonoBehaviour
{
    public float moveSpeed = 1f; // Speed of movement
    Slider slider; 
    public Vector2 randomDirection; 

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    private Vector2 minWorldPos, maxWorldPos;
    private float ballRadius, minX, maxX, minY, maxY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        slider = SliderManager.instance.slider;
        // Initialize the first random direction
        ChangeDirection();
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        AssignColor();
        minWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        maxWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        ballRadius = transform.localScale.x / 2f; 
        minX = minWorldPos.x + ballRadius;
        maxX = maxWorldPos.x - ballRadius;
        minY = minWorldPos.y + ballRadius;
        maxY = maxWorldPos.y - ballRadius;
    }
    void AssignColor()
    {
        if (gameObject.tag == "Rock") {
            spriteRenderer.color = GameManager.Instance.RockColor;
        }
        if (gameObject.tag == "Scissor") {
            spriteRenderer.color = GameManager.Instance.ScissorColor;
        }
        if (gameObject.tag == "Paper") {
            spriteRenderer.color = GameManager.Instance.PaperColor;
        }

    }

    void Update()
    {        
        if (slider != null)
        {
            moveSpeed = slider.value;
        }

        CheckWallHit();
        rb.velocity = rb.velocity.normalized * moveSpeed;
    }

    void CheckWallHit()
    {
        Vector2 ballPos = transform.position;

        if (ballPos.x >= maxX && rb.velocity.x > 0) {
            rb.velocity = Vector2.Reflect(rb.velocity, new Vector2(-1f, 0f));
        }
        if (ballPos.y <= minY && rb.velocity.y < 0) {
            rb.velocity = Vector2.Reflect(rb.velocity,  new Vector2(0f, 1f));
        }
        if (ballPos.y >= maxY && rb.velocity.y > 0) {
            rb.velocity = Vector2.Reflect(rb.velocity,  new Vector2(0f, -1f));
        }
        if (ballPos.x <= minX && rb.velocity.x < 0) {
            rb.velocity = Vector2.Reflect(rb.velocity, new Vector2(1f, 0f) );
        }
    }

    void ChangeDirection()
    {
        randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        rb.velocity = randomDirection*moveSpeed;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {   
        if (gameObject.tag == "Scissor" && collision.gameObject.CompareTag("Rock")) {
            spriteRenderer.color = GameManager.Instance.RockColor;
            gameObject.tag = "Rock";
        }
        if (gameObject.tag == "Rock" && collision.gameObject.CompareTag("Paper")) {
            spriteRenderer.color = GameManager.Instance.PaperColor;
            gameObject.tag = "Paper";
        }
        if (gameObject.tag == "Paper" && collision.gameObject.CompareTag("Scissor")) {
            spriteRenderer.color = GameManager.Instance.ScissorColor;
            gameObject.tag = "Scissor";
        }
        
    }

    void OnMouseDown()
    {
        ChangeDirection();
    }
}
