using UnityEngine;

public class DoorPivot : MonoBehaviour
{
    public float openAngle = 90f;      
    public float speed = 100f;         

    private bool isOpening = false;
    private float currentAngle = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isOpening)
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
