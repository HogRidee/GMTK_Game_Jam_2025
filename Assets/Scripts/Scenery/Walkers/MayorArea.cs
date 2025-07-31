using UnityEngine;

public class MayorArea : MonoBehaviour
{
    private Mayor _mayor;

    private void Start()
    {
        _mayor = GetComponentInParent<Mayor>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered Mayor area.");
            _mayor.SetPlayerInArea(true, other.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited Mayor area.");
            _mayor.SetPlayerInArea(false, null);
        }
    }
}
