using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private int _capacityKnife;
    [SerializeField] private int _levelNumber;

    public int CapacityKnife => _capacityKnife;
    public int LevelNumber => _levelNumber;


}
