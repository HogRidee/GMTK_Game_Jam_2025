using UnityEngine;

public class NeighborhoodController : MonoBehaviour
{
    public static NeighborhoodController Instance { get; private set; }

    [SerializeField] private int _maxResidents = 17;

    private int _residentCount = 0;

    public int TotalEnteredCivilians { get; private set; } = 0;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public bool CanSpawnResident()
    {
        return _residentCount < _maxResidents;
    }

    public void RegisterResidentEntry()
    {
        _residentCount++;
        TotalEnteredCivilians++;
        Debug.Log($"[Neighborhood] Civiles activos: {_residentCount} | Total acumulado: {TotalEnteredCivilians}");
    }

    public void UnregisterResident()
    {
        _residentCount = Mathf.Max(0, _residentCount - 1);
    }
}
