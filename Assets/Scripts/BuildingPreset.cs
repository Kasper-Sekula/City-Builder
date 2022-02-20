using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Building Preset", menuName = "New Building Preset")]
public class BuildingPreset : ScriptableObject
{
    [SerializeField] public int cost;
    [SerializeField] public int costPerTurn;
    [SerializeField] public GameObject prefab;
    [SerializeField] public int population;
    [SerializeField] public int jobs;
    [SerializeField] public int food;

}
