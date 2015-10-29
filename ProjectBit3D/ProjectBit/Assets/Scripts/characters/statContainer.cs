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
    private namedStat[] attributeList;

    //stats
    private SecondaryStat health; //holds health information
    private SecondaryStat mana;
    private SecondaryStat stamina;
    private float _spd;
    private float _dmg;
    private float _mdmg;




    //constructors
    public statContainer()
    {
        attributeList = null;
        health= new SecondaryStat();
        mana = new SecondaryStat();
        stamina = new SecondaryStat();
    }

    public statContainer(string type)
    {
        health = new SecondaryStat();
        mana = new SecondaryStat();
        stamina = new SecondaryStat();
        if (type == "entity")
        {
            constructEntity();
        }
    }
    
    private void constructEntity()
    {
        attributeList = new namedStat[6];
        attributeList[0] = new namedStat("Strength");
        attributeList[1] = new namedStat("Intelligence");
        attributeList[2] = new namedStat("Agility");
        attributeList[3] = new namedStat("Dexterity");
        attributeList[4] = new namedStat("Constitution");
        attributeList[5] = new namedStat("Wisdom");
    }


    //properties
    public int this[string attribute]
    {
        get { return findAttribute(attribute).Amount; }
        private set { findAttribute(attribute).Amount = value; }
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
        set
        {
            switch (stat)
            {
                case "Health": partSetter(health, part,value); break;
                case "Mana": partSetter(mana, part,value); break;
                case "Stamina": partSetter(stamina, part,value);break;
            }
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
    private void partSetter(SecondaryStat stat,string part,int value)
    {
        switch (part)
        {
            case "Max": stat.Max=value; break;
            case "Current": stat.Current=value; break;
            case "Regeneration": stat.Regeneration=value; break;
        }
    }

    //auxilary methods
    private namedStat findAttribute(string name)
    {
        int n = 0;
        int min = 0;
        int max = attributeList.Length;
        while(n!= min || n!=max)
        {
            n = (min + max) / 2;
            if (min + 1 == max)
                if (attributeList[max].Name.CompareTo(name) == 0)
                    return attributeList[n];
            int pos = attributeList[n].Name.CompareTo(name);
            if (pos == 0)
                return attributeList[n];
            if (pos < 0)
                min = n;
            else
                max = n;
        }
        return new namedStat("error",-1);
    }

    private void sortAttribute()//heapsorts the attribute list
    {
        int length = attributeList.Length;
        for(int i = length/2; i > 0; i--)
            heap(i, length);
        for(int i = length; i > 0; i--)
        {
            swapAttribute(i, 0);
            heap(0, i);
        }
    }

    private void heap(int i,int l)
    {
        if (i * 2 < l) {
            if (i * 2 + 1 < l)
            {
                if (attributeList[i * 2].Name.CompareTo(attributeList[i * 2 + 1]) > 0)
                {
                    if (attributeList[i].Name.CompareTo(attributeList[i * 2 + 1]) > 0)
                    {
                        swapAttribute(i, i * 2 + 1);
                        heap(i * 2 + 1, l);
                    }
                }
                else
                    if (attributeList[i].Name.CompareTo(attributeList[i * 2]) > 0)
                    {
                        swapAttribute(i, i * 2);
                        heap(i * 2, l);
                    }
            }
            else
                if (attributeList[i].Name.CompareTo(attributeList[i * 2]) > 0)
                {
                    swapAttribute(i, i * 2);
                    heap(i * 2, l);
                }
        }
        else
            if (attributeList[i].Name.CompareTo(attributeList[i * 2]) > 0)
            {
                swapAttribute(i, i * 2);
                heap(i * 2, l);
            }
    }

    private void swapAttribute(int i, int j)
    {
        namedStat h = attributeList[i];
        attributeList[i] = attributeList[j];
        attributeList[j] = h;
    }


    //setting
    private void calcStats()
    {
        health.Max = (int)(this["Constitution"] * CONCONS);
        mana.Max = (int)(this["Wisdom"] * WISCONS);
        stamina.Max = (int)(this["Endurance"] * ENDCONS);
        _spd = (this["Agility"] * AGICONS);
        _dmg = (this["Strength"] * STRCONS);
        _mdmg = (this["Intelligence"] * INTCONS);
    }//*/

    public void addStat(string name,int amount)
    {
        if(atrPoints> amount)
        {
            atrPoints -= amount;
            this[name] += amount;
        }
      //  calcStats();
    }

}
