using UnityEngine;
using System.Collections;

public class Blockade : Structure
{
    void Awake()
    {
        generalType = GeneralType.Blockade;
        buildingType = BuildingType.Blockade;
    }

    // Use this for initialization
    void Start()
    {
        stats = new statContainer("Building");
        maxHealth = 100;
        health = 100;
    }
}
