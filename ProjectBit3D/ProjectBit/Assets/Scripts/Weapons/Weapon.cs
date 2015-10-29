using UnityEngine;
using System.Collections;

/// <summary>
/// Depending on what your hitting the damage will decrease more or less and the health of the weapon will decrease until broken accordingly
/// </summary>
public class Weapon : Destructible
{
    public Collider lastHit;
    int hitCount=0;

    int totalhits = 0;

    //Max amount of hits a weapon can take before it breaks
    private float _durability = 100;
    public int maxDura = 100;

    public float durability
    {
        get { return _durability; }
        set { _durability = Mathf.Clamp(value, 0, maxDura); }
    }

    bool fix = false;
    bool usable = true;

    public override void TakeDamage(int damage)
    {
        durability -= damage;
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
       
        //The Important part
        Destructible[] list = armor.gameObject.GetComponents<Destructible>();
        Debug.Log("hit#"+hitCount+"items" + list.Length);
        for (int i = 0; i < list.Length; i++)
        {
            list[i].TakeDamage(10);
        }
        hitCount++;

    }

}
