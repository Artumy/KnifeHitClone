using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Knife : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distanceToUp;
    [SerializeField] private KnifeInput _knifeInput;
    [SerializeField] private GameObject _gameOverPool;

    private Vector3 _targetPosition;
    private bool _isMoving;

    public void SetIsMoving(bool isMoving)
    {
        _isMoving = isMoving;
    }

    private void OnEnable()
    {
        _knifeInput.Touched += SetIsMoving;
    }

    private void OnDisable()
    {
        _knifeInput.Touched -= SetIsMoving;
    }

    private void Start()
    {
        _isMoving = false;
        _targetPosition = transform.position + new Vector3(0, _distanceToUp, 0);
    }
    private void FixedUpdate()
    {
        if (_isMoving)
            MoveToUp();
    }
    private void MoveToUp()
    {
        if (_targetPosition != transform.position)
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }

    private void SetIsMoving()
    {
        _isMoving = true;
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.TryGetComponent(out Knife knife))
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.AddComponent<Rigidbody2D>();
            if (_gameOverPool != null)
                gameObject.transform.SetParent(_gameOverPool.transform);
        }
    }
}
