using UnityEngine;

public class Civilian : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    void Update()
    {
        float distanceStep = _speed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x - distanceStep, transform.position.y);

        float leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x;

        if (transform.position.x < leftEdge - 1f)
        {
            Destroy(gameObject);
        }
    }
}
