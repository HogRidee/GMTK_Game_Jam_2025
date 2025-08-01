using UnityEngine;

public class IODoor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Civilian") || other.CompareTag("Thief"))
        {
            Debug.Log("NPC toc� la puerta");
            Destroy(other.gameObject);
        }
    }

}
