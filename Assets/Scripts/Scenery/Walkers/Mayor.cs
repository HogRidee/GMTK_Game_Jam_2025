using UnityEngine;

public class Mayor : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    void Update()
    {
        float distanceStep = _speed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x, transform.position.y - distanceStep);
    }
}
