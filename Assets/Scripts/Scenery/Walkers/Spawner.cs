using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float minX, minY, maxX, maxY;
    [SerializeField] private Transform[] _points;
    [SerializeField] private GameObject[] _walker;
    [SerializeField] private float _timeWalker;

    private float _nextTimeWalker;

    [SerializeField] private int _maxWalkerInScene;
    private List<GameObject> _activeWalkers = new List<GameObject>();
    private void Start()
    {
        maxX = _points.Max(Points => Points.position.x);
        minX = _points.Min(Points => Points.position.x);
        maxY = _points.Max(Points => Points.position.y);
        minY = _points.Min(Points => Points.position.y);
    }
    void Update()
    {
        _nextTimeWalker += Time.deltaTime;
        if (_nextTimeWalker >= _timeWalker)
        {
            _nextTimeWalker = 0;
            if (_activeWalkers.Count < _maxWalkerInScene)
                CreateWalker();
        }

        for (int i = _activeWalkers.Count - 1; i >= 0; i--)
        {
            if (_activeWalkers[i] == null)
            {
                _activeWalkers.RemoveAt(i);
            }
        }
    }

    private void CreateWalker()
    {
        int walkerNumber = Random.Range(0, _walker.Length);
        //Vector2 AletoryPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        Transform spawnPoint = _points[Random.Range(0, _points.Length)];
        Vector2 AletoryPosition = spawnPoint.position;

        GameObject newWalker = Instantiate(_walker[walkerNumber], AletoryPosition, Quaternion.identity);
        _activeWalkers.Add(newWalker);
    }
}
