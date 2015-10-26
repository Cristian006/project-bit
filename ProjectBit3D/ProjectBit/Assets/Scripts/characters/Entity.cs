using UnityEngine;

public class Entity : Destructible {
    //constants
    private float HPCONSTANT = 100f; //*str for health
    private float MPCONSTANT = 10f;  //*int for max mp
    private float STAMINACONSTANT = 10f;  //*endurance*agility for max stamina
    private float HPREGENCONSTANT = 5f;   //*endurance for health regen
    private float MPREGENCONSTANT = 0.5f; //*wisdom for mana regen
    private float STAMINAREGENCONSTANT = 2f;   //*str*endurance for stamina regen

    //basic stats
    private int _strength;
    private int _intelligence;
    private int _agility;
    private int _endurance;
    private int _wisdom;

    //derived stats
    private SecondaryStat _mana;
    private SecondaryStat _stamina;


    //Properties
    //primary
    public int Strength
    {
        get { return _strength; }
        protected set { _strength = Mathf.FloorToInt(Mathf.Clamp(value, 1, Mathf.Infinity)); }
    }
    public int Intelligence
    {
        get { return _strength; }
        protected set { _strength = Mathf.FloorToInt(Mathf.Clamp(value, 1, Mathf.Infinity)); }
    }
    public int Agility
    {
        get { return _strength; }
        protected set { _strength = Mathf.FloorToInt(Mathf.Clamp(value, 1, Mathf.Infinity)); }
    }
    public int Endurance
    {
        get { return _strength; }
        protected set { _strength = Mathf.FloorToInt(Mathf.Clamp(value, 1, Mathf.Infinity)); }
    }
    public int Wisdom
    {
        get { return _strength; }
        protected set { _strength = Mathf.FloorToInt(Mathf.Clamp(value, 1, Mathf.Infinity)); }
    }
    //secondary read-only so that display objects can find out these values for display
    //Internal changes will directly use the fields with dot notation
    public int MaxHealth { get { return _health.Max; } }
    public int MaxMana { get { return _mana.Max; } }
    public int MaxStamina { get { return _stamina.Max; } }

    public float CurrentHealth { get { return _health.Current; } }
    public float CurrentMana { get { return _mana.Current; } }
    public float CurrentStamina { get { return _stamina.Current; } }

    public float HealthRegeneration { get { return _health.Regeneration; } }
    public float ManaRegeneration { get { return _mana.Regeneration; } }
    public float StaminaRegeneration { get { return _stamina.Regeneration; } }


    //constructors
    void Awake()
    {
        //gameObject.tag = "Entity";
        Strength = 0;
        Intelligence = 0;
        Agility = 0;
        Wisdom = 0;
        Endurance = 0;
        _health = new SecondaryStat();
        _mana = new SecondaryStat();
        _stamina = new SecondaryStat();
        calculateStats();
    }


    //private methods
    private void calculateStats()
    {
        _health.Current = _health.Max = (int)HPCONSTANT * Strength;
        _mana.Current = _mana.Max = (int)MPCONSTANT * Intelligence;
        _stamina.Current = _stamina.Max = (int)STAMINACONSTANT * Endurance * Agility;
        _health.Regeneration = HPREGENCONSTANT * Endurance;
        _mana.Regeneration = MPREGENCONSTANT * Wisdom;
        _stamina.Regeneration = STAMINAREGENCONSTANT * Strength * Endurance;
    }



    //public methods
    public override void TakeDamage(int damage)
    {
        Debug.Log(gameObject.name);
        _health.Current -= damage;
        if (CurrentHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        //Kill Entity
        Debug.Log("Im hit");
        Destroy(this.gameObject);//either this isn't working or something isn't going right with weapon collision
    }
}
