using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Building Preset", menuName = "New Building Preset")]
public class BuildingPreset : ScriptableObject
{
    [SerializeField] int cost;
    [SerializeField] int costPerTurn;
    [SerializeField] GameObject prefab;
    [SerializeField] int population;
    [SerializeField] int jobs;
    [SerializeField] int food;
}
