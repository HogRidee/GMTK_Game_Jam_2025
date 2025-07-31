using UnityEngine;

public class DoorPivot : MonoBehaviour
{
    public float openAngle = 85f;
    public float speed = 450f;

    private bool isOpening = false;
    private float currentAngle = 0f;

    [HideInInspector] public bool playerInArea = false;

    void Update()
    {
        //Debug.Log($"Player in area: {playerInArea}, Is opening: {isOpening}");
        if (playerInArea && Input.GetKeyDown(KeyCode.Space) && !isOpening)
        {
            isOpening = true;
        }

        if (isOpening && currentAngle < openAngle)
        {
            float rotationStep = speed * Time.deltaTime;
            float angleToRotate = Mathf.Min(rotationStep, openAngle - currentAngle);

            transform.Rotate(0f, 0f, angleToRotate);
            currentAngle += angleToRotate;

            if (currentAngle >= openAngle)
            {
                isOpening = false;
            }
        }
    }
}
