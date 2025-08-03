using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private float _baseSpeed = 12f;
    private float _currentSpeed;
    private bool _isFleeing = false;

    void Start()
    {
        _currentSpeed = _baseSpeed;
    }

    void Update()
    {
        float step = _currentSpeed * Time.deltaTime;

        if (_isFleeing)
        {
            transform.position += Vector3.right * step;

            float rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)).x;
            if (transform.position.x > rightEdge + 1f)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            transform.position += Vector3.left * step;

            float leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x;
            if (transform.position.x < leftEdge - 1f)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("DoorArea"))
        {
            Debug.Log("GAME OVER");
            // Add game over logic here, such as showing a game over screen or resetting the game
            //UnityEditor.EditorApplication.isPlaying = false; // For Unity Editor, use this line to stop play mode
            Application.Quit();
        }
    }
    public void FleeToRight()
    {
        _currentSpeed = _baseSpeed * 0.5f;
        _isFleeing = true;
    }
}
