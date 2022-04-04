using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    [SerializeField] private List<GameObject> _pool = new List<GameObject>();

    public int Capacity => _capacity;

    protected void Initialize()
    {
        for (int i = 0; i < _pool.Count; i++)
        {
            //GameObject spawned = Instantiate(prefab, _container.transform);
            //spawned.SetActive(false);

            //_pool.Add(spawned);

            _pool[i].SetActive(false);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }

    protected void ReInitialize()
    {
        for (int i = 0; i < _pool.Count; i++)
        {
            _pool[i].SetActive(false);
            _pool[i].transform.SetParent(_container.transform, true);
            _pool[i].transform.localPosition = Vector3.zero;
            _pool[i].transform.localRotation = Quaternion.identity;
            _pool[i].transform.GetComponent<KnifeInput>().enabled = true;
        }
    }

    public void SetCapacity(int capacity)
    {
        _capacity = capacity;
    }
}
