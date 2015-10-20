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
    bool repairable = true;
    public bool meleeWeapon = true;

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
            repairable = true;
        }
    }

    public void Repare()
    {
        if (repairable)
        {
            //Repair code goes here
        }
    }

    void OnTriggerEnter(Collider outside)
    {
        if (meleeWeapon)
        {
            Entity enemy = (Entity)outside.gameObject.GetComponent("Entity");
            if (enemy.name == "Entity")
                enemy.TakeDamage(10);
        }
    }
}
