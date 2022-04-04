using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnifeInput : MonoBehaviour
{
    public event UnityAction Touched;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Touched?.Invoke();
    }
}
