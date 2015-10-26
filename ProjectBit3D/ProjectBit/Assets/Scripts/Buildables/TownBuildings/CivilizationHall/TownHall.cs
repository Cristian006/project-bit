using UnityEngine;
using System.Collections;

public class TownHall : Building
{

    // Use this for initialization
    void Start()
    {
        _health = new SecondaryStat();
        maxHealth = 100;
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
