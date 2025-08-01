using UnityEngine;

public class Civilian : MonoBehaviour
{
    [SerializeField] private float _baseSpeed = 10f;
    private float _currentSpeed;

    void Start()
    {
        _currentSpeed = _baseSpeed;
    }

    void Update()
    {
        float step = _currentSpeed * Time.deltaTime;
        transform.position += Vector3.left * step;

        float leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x;
        if (transform.position.x < leftEdge - 1f)
        {
            Destroy(gameObject);
        }
    }

    public void BoostSpeed()
    {
        _currentSpeed = _baseSpeed * 2f;
    }
}
