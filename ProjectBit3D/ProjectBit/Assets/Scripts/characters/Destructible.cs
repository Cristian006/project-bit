using UnityEngine;
using System.Collections;
/// <summary>
/// Handle the Take Damage Function.
/// Anything that is destructible is also selectable.
/// </summary>
public class Destructible : MonoBehaviour
{
    //identity strings
    protected string Max { get { return "Max"; } }
    protected string Current { get { return "Current"; } }
    protected string Regeneration { get { return "Regeneration"; } }
    protected string Health { get { return "Health"; } }
    protected string Mana { get { return "Mana"; } }
    protected string Stamina { get { return "Stamina"; } }

    //stats
    protected statContainer stats;

    public int maxHealth
    {
        protected set { stats[Health,Max] = value; }
        get { return stats[Health, Max]; }
    }

    public int health
    {
        protected set { stats[Health, Current] = value; }
        get { return stats[Health, Current]; }
    }

    // Use this for initialization
    void Start()
    {
        stats= new statContainer("Entity");
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
