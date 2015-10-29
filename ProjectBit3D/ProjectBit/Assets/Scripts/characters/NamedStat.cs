using UnityEngine;
using System.Collections;

public class namedStat{
    private string name;
    private int amount;


    public int Amount
    {
        get { return amount; }
        set
        {
            amount = value;
        }
    }


    public string Name
    {
        get { return name; }
    }
    

    public namedStat(string _name)
    {
        name = _name;
        amount = 0;
    }

    public namedStat(string _name,int _amount)
    {
        name = _name;
        amount = _amount;
    }

}
