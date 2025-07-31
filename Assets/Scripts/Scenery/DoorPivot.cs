using UnityEngine;

public class DoorPivot : MonoBehaviour
{
    public float openAngle = 85f;
    public float speed = 450f;

    private bool _isRotating = false;
    private float _currentAngle = 0f;
    private bool _isOpen = false;

    [HideInInspector] public bool playerInArea = false;

    void Update()
    {

        if (playerInArea && Input.GetKeyDown(KeyCode.Space) && !_isRotating)
        {
            _isRotating = true;
        }

        if (_isRotating)
        {
            float rotationStep = speed * Time.deltaTime;
            float angleToRotate = Mathf.Min(rotationStep, openAngle - _currentAngle);

            float direction = _isOpen ? -1f : 1f;
            transform.Rotate(0f, 0f, direction * angleToRotate);
            _currentAngle += angleToRotate;

            if (_currentAngle >= openAngle)
            {
                _isRotating = false;
                _isOpen = !_isOpen;    
                _currentAngle = 0f;     
            }
        }
    }
}
