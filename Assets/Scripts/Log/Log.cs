using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.TryGetComponent(out Knife knife))
        {
            knife.transform.SetParent(gameObject.transform, true);
            knife.GetComponent<KnifeInput>().enabled = false;
            knife.SetIsMoving(false);
        }
    }
}
