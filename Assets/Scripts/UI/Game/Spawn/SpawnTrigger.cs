using UnityEngine;
using System.Collections;

public class SpawnTrigger : MonoBehaviour
{
    [Header("SpawnManager")]
    [SerializeField] private SpawnManager spawnManager;

    [Header("Spawn Timing")]
    [SerializeField] private float _minDelay = 5f;
    [SerializeField] private float _extraRandomDelay = 3f;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnType nextType = GetWeightedRandomSpawnType();

            spawnManager.ScheduleSpawn(nextType, _minDelay+ Random.Range(0.5f, _extraRandomDelay));

            float delay = Random.Range(0.5f, _extraRandomDelay);
            yield return new WaitForSeconds(delay);
        }
    }

    private SpawnType GetWeightedRandomSpawnType()
    {
        int mayorWeight = 1;
        int civilianWeight = 6;
        int thiefWeight = 7;

        int total = mayorWeight + civilianWeight + thiefWeight;
        int rand = Random.Range(0, total);

        if (rand < mayorWeight)
            return SpawnType.Mayor;
        else if (rand < mayorWeight + civilianWeight)
            return SpawnType.Civilian;
        else
            return SpawnType.Thief;
    }
}