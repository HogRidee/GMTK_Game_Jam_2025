using UnityEngine;

public class Civilian : MonoBehaviour
{
    [SerializeField] private float _baseSpeed = 10f;
    [SerializeField] private GameObject _residentPrefab;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Neighborhood"))
        {
            Vector2 centerPos = other.bounds.center;
            GameObject newResident = Instantiate(_residentPrefab, centerPos, Quaternion.identity);

            ResidentCivilian resident = newResident.GetComponent<ResidentCivilian>();
            if (resident != null)
                resident.SetAreaBounds(other.bounds);
            Destroy(gameObject);
        }
    }
}
