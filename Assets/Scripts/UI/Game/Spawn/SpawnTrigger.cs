using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    [Header("SpawnManager")]
    [SerializeField] private SpawnManager spawnManager;

    void Start()
    {
        spawnManager.ScheduleSpawn(SpawnType.Civilian, 5f);
        spawnManager.ScheduleSpawn(SpawnType.Mayor, 6f);
        spawnManager.ScheduleSpawn(SpawnType.Thief, 7f);
    }
}