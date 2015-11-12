using UnityEngine;

public class Entity : Destructible
{
    //Add in all player types here
    public enum EntityType
    {
        /// <summary>
        /// Priority: Player's Control
        /// EX: The main character
        /// </summary>
        Player,
        /// <summary>
        /// Priority: attack resource buildings, looting all resources
        /// EX: Fast but weak troops
        /// </summary>
        Resource,
        /// <summary>
        /// Priority: Attack all defensive structures
        /// EX: Tanky troops
        /// </summary>
        Defense,
        /// <summary>
        /// Priority: attack closest
        /// EX: generic troop
        /// </summary>
        All,
        /// <summary>
        /// Priority: attack Blockades, Breaching through enemy Defense walls
        /// Ex: tanky slow troops
        /// </summary>
        Breacher,
        /// <summary>
        /// Priority: attack defending enemy troops
        /// </summary>
        Troops
    }

    private int playerID;
    public int PlayerID
    {
        get { return playerID; }
        set { playerID = value; }
    }

    public EntityType entityType = new EntityType();

    private RegeneratingResource _mana;
    private RegeneratingResource _stamina;

    //Properties
    public int this[string statName]
    {
        get { return stats[statName]; }
    }
    //secondary read-only so that display objects can find out these values for display
    //Internal changes will directly use the fields with dot notation
    public int MaxHealth { get { return (int)stats[statContainer.Health, statContainer.Max]; } }
    public int MaxMana { get { return (int)stats[statContainer.Mana, statContainer.Max]; } }
    public int MaxStamina { get { return (int)stats[statContainer.Stamina, statContainer.Max]; } }

    public float CurrentHealth { get { return stats[statContainer.Health, statContainer.Current]; } protected set { stats[statContainer.Health, statContainer.Current] = (int)value; } }
    public float CurrentMana { get { return stats[statContainer.Mana, statContainer.Current]; } protected set { stats[statContainer.Health, statContainer.Current] = (int)value; } }
    public float CurrentStamina { get { return stats[statContainer.Stamina, statContainer.Current]; } protected set { stats[statContainer.Health, statContainer.Current] = (int)value; } }

    public float HealthRegeneration { get { return stats[statContainer.Health, statContainer.Regeneration]; } }
    public float ManaRegeneration { get { return stats[statContainer.Mana, statContainer.Regeneration]; } }
    public float StaminaRegeneration { get { return stats[statContainer.Stamina, statContainer.Regeneration]; } }


    //constructors
    void Awake()
    {
        //gameObject.tag = "Entity";
        stats = new statContainer(statContainer.Entity);
        CurrentHealth = maxHealth;
    }
    

    //public methods
    public override void TakeDamage(int damage)
    {
        //Debug.Log(gameObject.name+"Current Health:"+CurrentHealth);
        CurrentHealth-= damage;
        if (CurrentHealth <= 0)
        {
            Death();
        }
    }

    public override void Death()
    {
        //Kill Entity
        Debug.Log("Im hit");
        this.gameObject.SetActive(false);
    }
}
