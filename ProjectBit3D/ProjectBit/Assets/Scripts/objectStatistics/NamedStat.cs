using UnityEngine;
using System.Collections;

public class namedStat{
    protected string name;
    protected int current;

    //Properties
    public virtual int Current
    {
        get { return current; }
        set
        {
            current = value;
        }
    }


    public string Name
    {
        get { return name; }
    }


    //Constructor
    protected namedStat()
    {
        name = "null";
        current = 0;
    }
    
    public namedStat(string name)
    {
        this.name =name;
        current = 0;
    }

    public namedStat(string _name,int _amount)
    {
        name = _name;
        current = _amount;
    }

}