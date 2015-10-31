using UnityEngine;

public class Entity : Destructible {

    private SecondaryStat _mana;
    private SecondaryStat _stamina;

    //Properties
    public int this[string statName]
    {
        get { return stats[statName]; }
    }
    //secondary read-only so that display objects can find out these values for display
    //Internal changes will directly use the fields with dot notation
    public int MaxHealth { get { return stats[Health,Max]; } }
    public int MaxMana { get { return stats[Mana, Max]; } }
    public int MaxStamina { get { return stats[Stamina, Max]; } }

    public float CurrentHealth { get { return stats[Health, Current]; } private set { stats[Health, Current] = (int)value; } }
    public float CurrentMana { get { return stats[Mana, Current]; } private set { stats[Health, Current] = (int)value; } }
    public float CurrentStamina { get { return stats[Stamina, Current]; } private set { stats[Health, Current] = (int)value; } }

    public float HealthRegeneration { get { return stats[Health, Regeneration]; } }
    public float ManaRegeneration { get { return stats[Mana, Regeneration]; } }
    public float StaminaRegeneration { get { return stats[Stamina, Regeneration]; } }


    //constructors
    void Awake()
    {
        //gameObject.tag = "Entity";
        stats = new statContainer(statContainer.Entity);
        CurrentHealth = maxHealth;
        _mana = new SecondaryStat();
        _stamina = new SecondaryStat();
    }




    //public methods
    public override void TakeDamage(int damage)
    {
        Debug.Log(gameObject.name+"Current Health:"+CurrentHealth);
        CurrentHealth-= damage;
        if (CurrentHealth <= 0)
        {
            Death();
        }
    }

    public virtual void Death()
    {
        //Kill Entity
        Debug.Log("Im hit");
        Destroy(this.gameObject);//either this isn't working or something isn't going right with weapon collision
    }
}
