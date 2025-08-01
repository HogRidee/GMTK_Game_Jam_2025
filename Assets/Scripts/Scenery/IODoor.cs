using UnityEngine;

public class IODoor : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Civilian") || collision.gameObject.CompareTag("Thief"))
        {
            //Debug.Log("NPC colisionó con la puerta");
            Destroy(collision.gameObject);
        }
    }
}

