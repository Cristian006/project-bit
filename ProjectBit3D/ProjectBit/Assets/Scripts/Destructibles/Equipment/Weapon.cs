using UnityEngine;
using System.Collections;

/// <summary>
/// Depending on what your hitting the damage will decrease more or less and the health of the weapon will decrease until broken accordingly
/// </summary>
public class Weapon : Equipment
{
    public Collider lastHit;
    int hitCount=0;

    int totalhits = 0;

    //Max amount of hits a weapon can take before it breaks
    //TODO put that into statContainer
    private float _durability = 100;
    public int maxDura = 100;

    public Destructible destructible;
    private Destructible.CivilizationType civType;

    void OnEnable()
    {
        civType = destructible.civType;
    }

    public float durability
    {
        get { return _durability; }
        set { _durability = Mathf.Clamp(value, 0, maxDura); }
    }

    public override void TakeDamage(int damage)
    {
        durability -= damage;
    }


    //TODO
    //weapon hits armor
    //deal damage to:
    //  Armor
    //  Entity
    //if no armor just damage entity
    void OnTriggerEnter(Collider armor)
    {
        //if(armor.GetComponent<Destructible>().civType != civType)
        //{
            Equipment n = armor.gameObject.GetComponent<Equipment>();
            if (n != null) n.TakeDamage(10);
            //Debug.Log("hit#"+hitCount+"items" + list.Length);
            hitCount++;
        //}
    }
	
	public override void Fix()
	{
		
	}

	public override void Upgrade()
	{
		
	}

}
