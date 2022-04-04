using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Log))]
public class LogMover : MonoBehaviour
{
    [SerializeField] private float _angleSpeed;

    private void Update()
    {
        transform.Rotate(0, 0, _angleSpeed * Time.deltaTime);
    }
}
