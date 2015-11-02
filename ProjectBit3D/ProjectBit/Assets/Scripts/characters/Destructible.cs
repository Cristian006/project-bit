using UnityEngine;
using System.Collections;
/// <summary>
/// Handle the Take Damage Function.
/// Anything that is destructible is also selectable.
/// </summary>
public class Destructible : MonoBehaviour
{
    //stats
    protected statContainer stats;

    public int maxHealth
    {
        protected set { stats[statContainer.Health, statContainer.Max] = value; }
        get { return (int)stats[statContainer.Health, statContainer.Max]; }
    }

    public int health
    {
        protected set { stats[statContainer.Health, statContainer.Current] = value; }
        get { return (int)stats[statContainer.Health, statContainer.Current]; }
    }

    // Use this for initialization
    void Awake()
    {
        stats = new statContainer("Destructible");
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Death();
        Debug.Log("current health is:"+health);
    }

    public virtual void Death()
    {
        Destroy(this.gameObject);
    }

}
