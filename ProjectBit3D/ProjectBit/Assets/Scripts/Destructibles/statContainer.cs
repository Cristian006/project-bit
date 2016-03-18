using UnityEngine;


//requires a class Destructible with ENUMs STAT and ATTRIBUTE
public struct StatContainer
{
    const int STATS = 0, ATTRIBUTES = 1;

    //
    //Fields
    //
    Stat[] Stats;
    Attribute[] Attributes;
    int statCount;
    int attrCount;
    
    public delegate void varChange(float current, float change);

    //
    //Internal Structure declaration
    //
    struct Attribute
    {
        private float _value;
        Destructible.ATTRIBUTE _name;
        varChange changed;
        
        public Attribute(Destructible.ATTRIBUTE aName,float value = 0)
        {
            _value = value;
            _name = aName;
            changed = null;
        }

        public float value
        {
            set//TODO:More checks in place
            {
                float change = value - _value;
                _value = value;
                if (changed != null) changed(_value, change);
            }
            get { return _value; }
        }
        public varChange this[bool Set]
        {
            set
            {
                changed = Set?value:changed+value;
            }
        }
        public Destructible.ATTRIBUTE name
        {
            get { return _name; }
        }
    }


    public struct Stat
    {
        //CONSTANTS for indexed properties
        public enum statPart
        {
            CURRENT,
            MAX,
            REGEN
        }
        
        //fields
        private float currentValue;
        private float maxValue;
        private float regenPerSecond;
        private Destructible.STAT _name;
        
        //Delegates
        varChange currentChange;
        varChange maxChange;
        varChange regenChange;

        //Constructors
        public Stat(Destructible.STAT __name, float __maxValue=0, float __regenPerSecond=0)
        {
            _name = __name;
            currentValue = maxValue = __maxValue;
            regenPerSecond = __regenPerSecond;
            currentChange = null;
            maxChange = null;
            regenChange = null;
        }
        
        //Indexed Properties
        public float this[statPart stat]
        {
            get
            {
                switch (stat)
                {
                    case statPart.CURRENT: return this.currentValue;
                    case statPart.MAX: return this.maxValue;
                    case statPart.REGEN: return this.regenPerSecond;
                    default: return -1;
                }
            }
            set//TODO:add more checks to set
            {
                switch (stat)
                {
                    case statPart.CURRENT:
                        if (value > maxValue) value = maxValue;
                        if (currentChange != null) currentChange(value, value - currentValue);
                        currentValue = value;
                        break;
                    case statPart.MAX:
                        if (maxChange != null) maxChange(value, value - maxValue);
                        maxValue = value;
                        break;
                    case statPart.REGEN:
                        if (regenChange != null) regenChange(value, value - regenPerSecond);
                        regenPerSecond = value;
                        break;
                }
            }
        }

        public varChange this[statPart stat,bool setAll]
        {
            get
            {
                switch (stat)
                {
                    case statPart.CURRENT: return currentChange;
                    case statPart.MAX: return maxChange;
                    case statPart.REGEN: return regenChange;
                    default: return null;
                }
            }
            set
            {
                switch (stat)
                {
                    case statPart.CURRENT:
                        if (setAll)
                        {
                            currentChange = value;
                        }
                        else
                        {
                            currentChange += value;
                        }
                        break;
                    case statPart.MAX:
                        maxChange = setAll ? value : maxChange + value;
                        break;
                    case statPart.REGEN:
                        regenChange = setAll ? value : regenChange + value;
                        break;
                }
            }
        }

        //Properties
        public Destructible.STAT name
        {
            get { return _name; }
        }
        
        //Update Functions
        public void passTick()
        {
            this[statPart.CURRENT] += regenPerSecond * Time.deltaTime;
        }
    }


    //
    //Constructors
    //
    //Initialize array but leave array empty
    public StatContainer(int numStats,int numAttr)
    {
        Stats = new Stat[numStats];
        Attributes = new Attribute[numAttr];
        attrCount = statCount = 0;
    }

    //
    //Indexed Properties
    //

    //
    //Most current indexed property
    public float this[Destructible.STAT name, Stat.statPart stat]
    {
        get
        {
            int ID = getStatIndex(name);
            if (ID < 0) return -1;
            return Stats[ID][stat];
        }
        set
        {
            int ID = getStatIndex(name);
            if (ID < 0)
            {
                Debug.Log("SOMETHING WENT WRONG!!   " + name);
                return;
            }

            Stats[ID][stat] = value;
        }
    }

    public float this[Destructible.ATTRIBUTE name]
    {
        set
        {
            int ID = getAttributeIndex(name);
            if (ID < 0) return;
            Attributes[ID].value = value;
        }
        get
        {
            int ID = getAttributeIndex(name);
            if (ID < 0)
            {
                Debug.Log("Uh Oh" + name.ToString()); return -1;
            }
            return Attributes[ID].value;
        }
    }
    public varChange this[Destructible.STAT name, Stat.statPart stat,bool setAll]
    {
        get
        {
            int ID = getStatIndex(name);
            if (ID < 0) return null;
            return Stats[ID][stat,setAll];
        }//*/
        set
        {
            int ID = getStatIndex(name);
            Debug.Log("Delegate " + name + " " + stat + " " + value.ToString() + " " + ID.ToString());
            if (ID < 0)
            {
                Debug.Log("SOMETHING WENT WRONG!!   " + name);
                return;
            }

            Stats[ID][stat,setAll] = value;
        }
    }

    public varChange this[Destructible.ATTRIBUTE name,bool setAll]
    {
        set
        {
            int ID = getAttributeIndex(name);
            if (ID < 0) return;
            Attributes[ID][setAll] = value;
        }
    }
    
    //Adding Elements
    public bool addStat(Destructible.STAT name)
    {
        if (hasStat(name)) return false;
        else
        {
            if (statCount >= Stats.Length)
            {
                Stat[] temp = Stats;
                Stats = new Stat[statCount + 3];
                for (int i = 0; i < statCount; i++)
                    Stats[i] = temp[i];
            }
            Stats[statCount] = new Stat(name, 1);
            statCount++;
        }
        return true;
    }

    public bool addAttribute(Destructible.ATTRIBUTE name)
    {
        if (hasAttribute(name)) return false;
        else
        {
            if (attrCount >= Attributes.Length)
            {
                Attribute[] temp = Attributes;
                Attributes = new Attribute[attrCount + 3];
                for (int i = 0; i < attrCount; i++)
                    Attributes[i] = temp[i];
            }
            Attributes[attrCount] = new Attribute(name);
            attrCount++;
        }
        return true;
    }

    
    //internal array navigators
    private int getStatIndex(Destructible.STAT name)
    {
        for (int i = 0; i < statCount; i++)
        {
            if (Stats[i].name == name) return i;
        }
        return -1;
    }

    private bool hasStat(Destructible.STAT name)
    {
        for (int i = 0; i < statCount; i++)
        {
            if (Stats[i].name == name) return true;
        }
        return false;
    }
    private int getAttributeIndex(Destructible.ATTRIBUTE name)
    {
        for (int i = 0; i < attrCount; i++)
        {
            if (Attributes[i].name == name) return i;
        }
        return -1;
    }

    private bool hasAttribute(Destructible.ATTRIBUTE name)
    {
        for (int i = 0; i < attrCount; i++)
        {
            if (Attributes[i].name == name) return true;
        }
        return false;
    }

    public void updateStats()
    {
        for (int i = 0; i < statCount; i++) {
            Stats[i].passTick();
        }
    }

}