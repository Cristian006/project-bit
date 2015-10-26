using UnityEngine;
using System.Collections;
/// <summary>
/// Handle the Take Damage Function.
/// Anything that is destructible is also selectable.
/// </summary>
public class Destructible : MonoBehaviour
{
    protected SecondaryStat _health;
    //TODO create properties for health and maxhealth

    public int maxHealth
    {
        protected set { _health.Max = value; }
        get { return _health.Max; }
    }

    public int health
    {
        protected set { _health.Current = value; }
        get { return _health.Current; }
    }

    // Use this for initialization
    void Start()
    {
        _health = new SecondaryStat();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //TODO
    //handle entity death when health <0;
    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy(this.gameObject);
        Debug.Log("current health is:"+health);
    }

}
