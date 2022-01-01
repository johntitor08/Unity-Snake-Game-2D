using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chicken_Controller : MonoBehaviour
{
    [SerializeField] float minX, maxX, minY, maxY;
    [SerializeField] Snake_Controller snake;
    [SerializeField] Text scoreText;
    int score;
    void Start()
    {
        RandomChickenPosition();
        score = 0;
    }

    void RandomChickenPosition()
        {
            transform.position = new Vector2(
                Mathf.Round(Random.Range(minX, maxX)) + 0.5f,
                Mathf.Round(Random.Range(minY, maxY)) + 0.5f
                );
        }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Snake"))
        {
            RandomChickenPosition();
            snake.CreateSegment();
            Time.timeScale += 0.004f;
            score++;
            scoreText.text = "Score : " + score.ToString();
        }
    
    }

}
