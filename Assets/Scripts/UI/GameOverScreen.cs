using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPool;

    private CanvasGroup _gameOverGroup;

    private void Start()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 0f;
    }

    private void Update()
    {
        if (_gameOverPool.transform.childCount > 0)
            ShowGameOverScreen();
    }

    private void ShowGameOverScreen()
    {
        _gameOverGroup.alpha = 1f;
    }
}
