using UnityEngine;

public class ResidentCivilian : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float changeDirectionTime = 0.5f;

    private Vector2 moveDirection;
    private float timer;

    private Bounds allowedArea;

    public void SetAreaBounds(Bounds bounds)
    {
        allowedArea = bounds;
    }

    void Start()
    {
        PickRandomDirection();
    }

    void Update()
    {
        Vector3 nextPos = transform.position + (Vector3)(moveDirection * moveSpeed * Time.deltaTime);

        if (!allowedArea.Contains(nextPos))
        {
            PickRandomDirection();
            return;
        }

        transform.position = nextPos;

        timer += Time.deltaTime;
        if (timer >= changeDirectionTime)
        {
            PickRandomDirection();
            timer = 0f;
        }
    }

    void PickRandomDirection()
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        moveDirection = new Vector2(x, y).normalized;
    }

    void OnDestroy()
    {
        if (NeighborhoodController.Instance != null)
            NeighborhoodController.Instance.UnregisterResident();
    }
}
