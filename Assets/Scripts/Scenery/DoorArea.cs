using UnityEngine;

public class DoorArea : MonoBehaviour
{
    private DoorPivot doorRotator;

    private void Start()
    {
        doorRotator = GetComponentInParent<Door>().GetComponentInChildren<DoorPivot>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            doorRotator.playerInArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            doorRotator.playerInArea = false;
        }
    }
}
