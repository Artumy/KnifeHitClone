using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private List<Level> _levels = new List<Level>();

    private int _currentLevel;

    private void Awake()
    {
        _currentLevel = 0;
    }

    private void OnEnable()
    {
        _spawner.Finished += LoadNextLevel;
    }

    private void OnDisable()
    {
        _spawner.Finished -= LoadNextLevel;
    }

    private void LoadNextLevel()
    {
        _currentLevel++;
        _spawner.SetCapacity(_levels[_currentLevel].CapacityKnife);
    }
}
