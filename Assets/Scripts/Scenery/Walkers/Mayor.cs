using UnityEngine;

public class Mayor : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _followSpeed = 3f;

    private bool _playerInArea = false;
    private Transform _playerTransform;

    void Update()
    {
        //Debug.Log($"Player in area: {_playerInArea}, Player transform: {_playerTransform}");

        if (!_playerInArea || !Input.GetKey(KeyCode.Z))
        {
            float distanceStep = _speed * Time.deltaTime;
            transform.position = new Vector2(transform.position.x, transform.position.y - distanceStep);
        }
        else if (_playerTransform != null)
        {
            Vector2 direction = (_playerTransform.position - transform.position).normalized;
            transform.position += (Vector3)direction * _followSpeed * Time.deltaTime;
        }

        Vector2 screenBottom = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0f));
        if (transform.position.y < screenBottom.y - 1f)
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayerInArea(bool inArea, Transform playerTransform)
    {
        _playerInArea = inArea;
        _playerTransform = playerTransform;
    }
}
