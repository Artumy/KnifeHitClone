using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : ObjectPool
{
    [SerializeField] private float _timeToSpawn;
    [SerializeField] private Log _log;
    [SerializeField] private SpawnKnifeOnLog _spawnKnifeOnLog;

    private float _elapsedTime;
    private int _currentKnife;

    public int CurrentKnife => _currentKnife;

    public event UnityAction Finished;

    private void OnEnable()
    {
        _spawnKnifeOnLog.StartKnifeSpawned += AddStartKnife;
    }

    private void OnDisable()
    {
        _spawnKnifeOnLog.StartKnifeSpawned -= AddStartKnife;
    }

    private void Start()
    {
        Initialize();
        _elapsedTime = 0;
        _currentKnife = 0;
    }

    private void Update()
    {
        if (_log.transform.childCount == _currentKnife && _currentKnife < Capacity)
            SpawnKnife();
        if (_log.transform.childCount == Capacity)
        {
            while(_log.transform.childCount != 0)
            {
                Rigidbody2D logRB = _log.transform.GetChild(0).GetComponent<Rigidbody2D>();
                _log.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
                logRB.bodyType = RigidbodyType2D.Dynamic;
                //_log.transform.GetChild(0).Translate(new Vector3(Random.Range(1, 4), Random.Range(1, 4), 0));
                logRB.AddTorque(Random.Range(-1200, 1200));
                logRB.AddForce(new Vector2(Random.Range(-300, 300), Random.Range(-300, 300)));
                _log.transform.GetChild(0).SetParent(null);
            }
            Invoke("SpawnNextLevel", 3f);
        }
    }

    private void SpawnKnife()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _timeToSpawn)
        {
            if (TryGetObject(out GameObject obj))
            {
                obj.SetActive(true);
                _elapsedTime = 0;
                _currentKnife++;
            }
        }
    }

    private void AddStartKnife(int knife)
    {
        _currentKnife += knife;
    }

    private void SpawnNextLevel()
    {
        Finished?.Invoke();
        ReInitialize();
        _currentKnife = 0;
        _spawnKnifeOnLog.DestroyKnifes();
        _spawnKnifeOnLog.SpawnKnifes();
    }
}
