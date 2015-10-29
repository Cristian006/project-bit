using UnityEngine;
using System.Collections;

public class statContainer{
    //Constants
    static float STRCONS = 100;
    static float INTCONS = 100;
    static float AGICONS = 100;
    static float ENDCONS = 100;
    static float CONCONS = 100;
    static float WISCONS = 100;

    //misc
    private int atrPoints;


    //attributes
    private int _str;   //dmg
    private int _int;   //mag damage
    private int _agi;   //speed
    private int _end;   //stam
    private int _con;   //hp
    private int _wis;   //mana

    //stats
    private SecondaryStat health; //holds health information
    private SecondaryStat mana;
    private SecondaryStat stamina;
    private float _spd;
    private float _dmg;
    private float _mdmg;




    //constructors
    statContainer()
    {
        _str=1;
        _int=1;   
        _agi=1;  
        _end=1; 
        _con=1; 
        _wis=1;
        health= new SecondaryStat();
        mana = new SecondaryStat();
        stamina = new SecondaryStat();
        _spd = 0f;
        _dmg = 0f;
        _mdmg = 0f;
        calcStats();
    }

    statContainer(int[] stats)
    {
        _str = stats[0];
        _int = stats[1];
        _agi = stats[2];
        _end = stats[3];
        _con = stats[4];
        _wis = stats[5];
        health = new SecondaryStat();
        mana = new SecondaryStat();
        stamina = new SecondaryStat();
        _spd = 0f;
        _dmg = 0f;
        _mdmg = 0f;
        calcStats();
    }




    //properies
    public int this[string attribute]
    {
        get
        {
            switch (attribute)
            {
                case "Strength": return _str;
                case "Intelligence": return _int;
                case "Agility": return _agi;
                case "Endurance": return _end;
                case "Constitutioin": return _con;
                case "Wisdom": return _wis;
            }
            return -1;
        }
        set
        {
            switch (attribute)
            {
                case "Strength": _str=value; break;
                case "Intelligence": _int = value; break;
                case "Agility": _agi = value; break;
                case "Endurance":  _end = value; break;
                case "Constitutioin":  _con = value; break;
                case "Wisdom": _wis = value; break;
            }
        }
    }

    
    public int this[string stat,string part]
    {
        get
        {
            switch (stat)
            {
                case "Health": return partChooser(health, part);
                case "Mana": return partChooser(mana, part);
                case "Stamina": return partChooser(stamina, part);
            }
            return -1;
        }
    }

    private int partChooser(SecondaryStat stat,string part)
    {
        switch (part)
        {
            case "Max": return stat.Max;
            case "Current": return stat.Current;
            case "Regeneration": return (int)stat.Regeneration;
        }
        return -1;
    }

    //setting
    private void calcStats()
    {
        health.Max = (int)(_con * CONCONS);
        mana.Max = (int)(_wis * WISCONS);
        stamina.Max = (int)(_end * ENDCONS);
        _spd = (_agi * AGICONS);
        _dmg = (_str * STRCONS);
        _mdmg = (_int * INTCONS);
    }

    public void addStat(string name,int amount)
    {
        if(atrPoints> amount)
        {
            atrPoints -= amount;
            this[name] += amount;
        }
        calcStats();
    }

}
