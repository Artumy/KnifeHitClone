using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnKnifeOnLog : MonoBehaviour
{
    [SerializeField] private int _minimum;
    [SerializeField] private int _maximum;
    [SerializeField] private float _radius;
    [SerializeField] private GameObject _knifePrefab;

    private List<GameObject> _knifeList = new List<GameObject>();

    public event UnityAction<int> StartKnifeSpawned;

    private const int circleDegrees = 360;

    private void Start()
    {
        SpawnKnifes();
    }

    Vector3 RandomCircle(Vector3 center, float radius, float angle)
    {
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }
    public void SpawnKnifes()
    {
        int knifeCount = Random.Range(_minimum, _maximum);
        StartKnifeSpawned?.Invoke(knifeCount);
        float frequencySpawn = circleDegrees / knifeCount;
        Vector3 center = transform.position;
        float degreeSpawn = 0f;
        for (int i = 0; i < knifeCount; i++)
        {
            Vector3 pos = RandomCircle(center, _radius, degreeSpawn);
            Quaternion changeRotation = Quaternion.Euler(Quaternion.identity.x, Quaternion.identity.y, circleDegrees / 2 - degreeSpawn);
            _knifeList.Add(Instantiate(_knifePrefab, pos, changeRotation));
            degreeSpawn += frequencySpawn;
        }
    }

    public void DestroyKnifes()
    {
        foreach (var knife in _knifeList)
            Destroy(knife);
    }
}
