using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake_Controller : MonoBehaviour
{
    Vector2 direction;
    [SerializeField] GameObject segmentPrefab;
    List<GameObject> segments = new List<GameObject>();
    float tekrar;

    void Start()
    {
        Reset();
        ResetSegment();
        tekrar = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetUserInput();
    }

    private void FixedUpdate()
    {
        SnakeMove();
        MoveSegment();
    }

    public void CreateSegment()
    {
        GameObject newSegment = Instantiate(segmentPrefab);
        newSegment.transform.position = segments[segments.Count - 1].transform.position;
        segments.Add(newSegment);
    }
    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Reset()
    {
        direction = Vector2.right;
        Time.timeScale = .1f;
    }

    void ResetSegment()
    {
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i]);
        }

        segments.Clear();
        segments.Add(gameObject);
        CreateSegment();
        
    }

    void MoveSegment()
    {
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].transform.position = segments[i - 1].transform.position;
        }
    }

    void SnakeMove()
    {
        float x, y;
        x = transform.position.x + direction.x;
        y = transform.position.y + direction.y;
        transform.position = new Vector2(x, y);
    }

    void GetUserInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector2.right;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            RestartGame();
        }

        if (collision.gameObject.CompareTag("Segment"))
        {

            tekrar++;
            if (tekrar >= 2)
            {
                RestartGame();
            }
        }
    }

}
