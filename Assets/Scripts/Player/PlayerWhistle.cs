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
        }
    }
}
