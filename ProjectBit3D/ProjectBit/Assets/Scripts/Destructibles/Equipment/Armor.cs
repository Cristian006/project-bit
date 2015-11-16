using UnityEngine;
using System.Collections;

public class Armor : Equipment
{
    // Use this for initialization
    void Start()
    {

    }

    //TODO
    //weapon collider hits armor zone
    //damage weapon
    void OnTriggerEnter(Collider weapon)
    {

    }

    public override void Fix()
    {

    }
    public override void TakeDamage(int damage)
    {//pass on damage to destructible attached to gameObject attached to the equipment gameObject
		Destructible n = this.gameObject.GetComponent<Destructible> ();
		if(n!=null)n.TakeDamage(damage);
    }
	public override void Upgrade()
    {

    }
}
