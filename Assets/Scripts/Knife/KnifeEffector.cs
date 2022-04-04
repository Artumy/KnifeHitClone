using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeEffector : MonoBehaviour
{
    [SerializeField] private GameObject _OnKnifeEffect;
    [SerializeField] private GameObject _OnLogEffect;

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.TryGetComponent(out Log log))
        {
            _OnLogEffect.SetActive(true);
        }
        if (collider2D.TryGetComponent(out Knife knife))
        {
            _OnKnifeEffect.SetActive(true);
        }

        Invoke("DesectivateEffects", 1f);
    }

    private void DesectivateEffects()
    {
        _OnKnifeEffect.SetActive(false);
        _OnLogEffect.SetActive(false);
    }
}
