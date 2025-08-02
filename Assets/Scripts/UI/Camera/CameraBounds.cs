using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    [SerializeField] private BoxCollider2D topBorder;
    [SerializeField] private BoxCollider2D bottomBorder;
    [SerializeField] private BoxCollider2D leftBorder;
    [SerializeField] private BoxCollider2D rightBorder;

    [SerializeField] private float thickness = 1f;

    void Start()
    {
        Camera cam = Camera.main;

        Vector2 bottomLeft = cam.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 topRight = cam.ViewportToWorldPoint(new Vector2(1, 1));

        float width = topRight.x - bottomLeft.x;
        float height = topRight.y - bottomLeft.y;

        leftBorder.transform.position = new Vector2(bottomLeft.x - thickness / 2f, 0);
        leftBorder.size = new Vector2(thickness, height + 2 * thickness);

        rightBorder.transform.position = new Vector2(topRight.x + thickness / 2f, 0);
        rightBorder.size = new Vector2(thickness, height + 2 * thickness);

        topBorder.transform.position = new Vector2(0, topRight.y + thickness / 2f);
        topBorder.size = new Vector2(width + 2 * thickness, thickness);

        bottomBorder.transform.position = new Vector2(0, bottomLeft.y - thickness / 2f);
        bottomBorder.size = new Vector2(width + 2 * thickness, thickness);
    }
}
