using UnityEngine;
using System.Collections;

/// <summary>
/// Depending on what your hitting the damage will decrease more or less and the health of the weapon will decrease until broken accordingly
/// </summary>
public class Weapon : Destructible
{
    private float _durability;
    public float durability
    {
        get { return _durability; }
        set { _durability = Mathf.Clamp(value, 0, Mathf.Infinity); }
    }

    bool fix = false;
    bool usable = true;

    public void TakeDamage(float damage)
    {
        if (durability <= 0)
        {
            fix = true;
            Break();
        }
    }

    public void Break()
    {
        if (fix)
        {
            usable = false;
        }
    }

    //TODO
    //weapon hits armor
    //deal damage to:
    //  Armor
    //  Entity
    //if no armor just damage entity
    void OnTriggerEnter(Collider armor)
    {
    }

}
