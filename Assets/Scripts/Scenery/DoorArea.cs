using UnityEngine;

public class DoorArea : MonoBehaviour
{
    private DoorPivot _doorRotator;

    private void Start()
    {
        _doorRotator = GetComponentInParent<Door>().GetComponentInChildren<DoorPivot>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _doorRotator.playerInArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _doorRotator.playerInArea = false;
        }
    }
}
