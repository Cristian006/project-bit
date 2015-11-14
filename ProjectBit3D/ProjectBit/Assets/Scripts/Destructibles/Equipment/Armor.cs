using UnityEngine;
using System.Collections;

public class Armor : Destructible , Equipment
{
    public bool broken
    {
        get { return false; }
        protected set { }
    }
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

    public void fix()
    {

    }
    public void damage()
    {

    }
    public void upgrade()
    {

    }
}
