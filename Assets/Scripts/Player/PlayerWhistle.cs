using UnityEngine;

public class PlayerWhistle : MonoBehaviour
{
    [SerializeField] private float detectionRangeY = 0.5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Civilian[] civilians = Object.FindObjectsByType<Civilian>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
            foreach (Civilian civilian in civilians)
            {
                if (Mathf.Abs(civilian.transform.position.y - transform.position.y) <= detectionRangeY)
                {
                    civilian.BoostSpeed();
                }
            }

            Thief[] thieves = Object.FindObjectsByType<Thief>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
            foreach (Thief thief in thieves)
            {
                if (Mathf.Abs(thief.transform.position.y - transform.position.y) <= detectionRangeY)
                {
                    thief.FleeToRight();
                }
            }

            Mayor[] mayors = Object.FindObjectsByType<Mayor>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
            foreach (Mayor mayor in mayors)
            {
                if (Mathf.Abs(mayor.transform.position.y - transform.position.y) <= detectionRangeY)
                {
                    //Debug.Log("Mayor in range, but no action defined.");
                }
                else
                {
                    //Debug.Log("Mayor not in range, no action taken.");
                }
            }
        }
    }
}
