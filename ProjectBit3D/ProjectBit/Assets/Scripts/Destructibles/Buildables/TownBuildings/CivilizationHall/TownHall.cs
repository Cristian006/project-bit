using UnityEngine;
using System.Collections;

public class TownHall : Structure
{
    void Awake()
    {
        generalType = GeneralType.Building;
        buildingType = BuildingType.TownHall;
    }

    // Use this for initialization
    void Start()
    {
        stats = new statContainer("Building");
        maxHealth = 100;
        health = 100;
    }
}
