using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SpawnType { Thief, Civilian, Mayor }

public class SpawnData
{
    public SpawnType    Type;
    public float        SpawnTime;
    public RectTransform IconRt;
}

public class SpawnManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private RectTransform spawnBarRt;
    [SerializeField] private GameObject    spawnIconPrefab;

    [Header("Lead Time")]
    [SerializeField] private float leadTime = 5f;

    [Header("Spawner")]
    // [SerializeField] private NPCSpawner npcSpawner;

    [Header("Icon Sprites")]
    [SerializeField] private Sprite thiefIcon;
    [SerializeField] private Sprite civilianIcon;
    [SerializeField] private Sprite mayorIcon;
    
    private List<SpawnData> queue = new List<SpawnData>();

    void Update()
    {
        float now   = Time.time;
        float halfW = spawnBarRt.rect.width * 0.5f;
        for (int i = queue.Count - 1; i >= 0; i--)
        {
            var sd   = queue[i];
            float tRem = sd.SpawnTime - now;

            if (tRem <= 0f)
            {
                // npcSpawner.RequestSpawn(sd.Type);
                Destroy(sd.IconRt.gameObject);
                queue.RemoveAt(i);
            }
            else
            {
                float norm = Mathf.Clamp01(tRem / leadTime);
                float x     = Mathf.Lerp(-halfW, +halfW, norm);
                sd.IconRt.anchoredPosition = new Vector2(x, 0);
            }
        }
    }
    
    public void ScheduleSpawn(SpawnType type, float delay)
    {
        float tSpawn = Time.time + delay;
        var iconGO   = Instantiate(spawnIconPrefab, spawnBarRt);
        var iconRt   = iconGO.GetComponent<RectTransform>();
        float halfW = spawnBarRt.rect.width * 0.5f;
        iconRt.anchoredPosition = new Vector2(+halfW, 0);
        var img = iconGO.GetComponent<Image>();
        img.sprite = GetSpriteForType(type);
        queue.Add(new SpawnData {
            Type      = type,
            SpawnTime = tSpawn,
            IconRt    = iconRt
        });
    }

    Sprite GetSpriteForType(SpawnType type)
    {
        switch (type)
        {
            case SpawnType.Thief:
                return thiefIcon;
            case SpawnType.Civilian:
                return civilianIcon;
            case SpawnType.Mayor:
                return mayorIcon;
            default:
                Debug.LogWarning($"Sprite not defined for {type}");
                return null;
        }
    }
}
