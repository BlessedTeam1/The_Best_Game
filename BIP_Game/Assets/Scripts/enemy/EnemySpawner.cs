using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [System.Serializable]
    public class EnemyType
    {
        public GameObject prefab;
        public float weight = 1f;        // higher = spawns more often, relative to the other types
        public Transform[] spawnPoints;  // optional; if empty, the shared spawn points are used
    }

    [SerializeField]
    private EnemyType[] _enemyTypes;
    [SerializeField]
    private Transform[] _spawnPoints;
    [SerializeField]
    private float _minimumSpawnTime;
    [SerializeField]
    private float _maximumSpawnTime;
    [SerializeField]
    private int _minimumGroupSize = 2;
    [SerializeField]
    private int _maximumGroupSize = 4;
    [SerializeField]
    private int _maxAliveEnemies = 15; // at the start
    [SerializeField]
    private float _limitIncreaseInterval = 5f; // seconds
    [SerializeField]
    private int _limitIncreaseAmount = 1;

    private float _timeUntilSpawn;

    // destroyed enemies turn into null and get cleaned up
    private readonly List<GameObject> _aliveEnemies = new List<GameObject>();

    void Awake()
    {
        SetTimeUntilSpawn();
    }

    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;

        if (_timeUntilSpawn <= 0f)
        {
            _aliveEnemies.RemoveAll(e => e == null);

            SpawnGroup();
            SetTimeUntilSpawn();
        }
    }

    private void SpawnGroup()
    {
        int groupSize = Random.Range(_minimumGroupSize, _maximumGroupSize + 1);
        var usedPoints = new List<Transform>();

        for (int i = 0; i < groupSize && _aliveEnemies.Count < CurrentLimit(); i++)
        {
            EnemyType type = PickEnemyType();
            if (type == null)
                return;

            Transform[] points = type.spawnPoints.Length > 0 ? type.spawnPoints : _spawnPoints;
            Vector3 position = PickSpawnPosition(points, usedPoints);

            _aliveEnemies.Add(Instantiate(type.prefab, position, Quaternion.identity));
        }
    }

    // prefers points not used yet in this group, so the group spreads out
    private Vector3 PickSpawnPosition(Transform[] points, List<Transform> usedPoints)
    {
        if (points.Length == 0)
            return transform.position;

        var freePoints = new List<Transform>();
        foreach (var point in points)
            if (!usedPoints.Contains(point))
                freePoints.Add(point);

        if (freePoints.Count > 0)
        {
            Transform point = freePoints[Random.Range(0, freePoints.Count)];
            usedPoints.Add(point);
            return point.position;
        }

        // every point is taken: reuse one, nudged a bit so enemies don't stack
        Vector3 reused = points[Random.Range(0, points.Length)].position;
        return reused + (Vector3)(Random.insideUnitCircle * 0.5f);
    }

    private EnemyType PickEnemyType()
    {
        float totalWeight = 0f;
        foreach (var type in _enemyTypes)
            totalWeight += type.weight;

        if (totalWeight <= 0f)
            return null; // no types, or all weights are 0

        float roll = Random.Range(0f, totalWeight);
        EnemyType picked = null;
        foreach (var type in _enemyTypes)
        {
            if (type.weight <= 0f)
                continue;
            picked = type;
            roll -= type.weight;
            if (roll < 0f)
                break;
        }

        return picked;
    }

    private int CurrentLimit()
    {
        int steps = Mathf.FloorToInt(Time.timeSinceLevelLoad / _limitIncreaseInterval);
        return _maxAliveEnemies + steps * _limitIncreaseAmount;
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }
}
