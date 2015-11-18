using UnityEngine;
using System.Collections;
/// <summary>
/// Handle the Take Damage Function.
/// Anything that is destructible is also selectable.
/// </summary>
public class Destructible : MonoBehaviour
{
    //ADD IN ALL CIVILIZATION TYPES HERE
    public enum CivilizationType
    {
        Greece,
        Japan
    }

    public CivilizationType civType = new CivilizationType();

    //stats
    protected statContainer stats;    
    protected int iD = 0;
    protected int level = 0;



    public int TeamID
    {
        protected set { iD = value; }//Protected to prevent accidental team changes.  Use the method to set team value in the rare case of team changes
        get { return iD; }
    }

    public int Level
    {
        get { return level; }
    }


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
    
    public void setTeam(int teamID)
    {
        this.TeamID = teamID;
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
