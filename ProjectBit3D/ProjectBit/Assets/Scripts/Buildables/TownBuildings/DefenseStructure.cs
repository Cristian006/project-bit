using UnityEngine;
using System.Collections;

public class DefenseStructure : Structure {

    void Awake()
    {
        generalType = GeneralType.Defense;
        buildingType = BuildingType.Defense;
    }

    // Use this for initialization
    void Start()
    {
        stats = new statContainer("Building");
        maxHealth = 100;
        health = 100;
    }
}
