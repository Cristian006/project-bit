using UnityEngine;
using System.Collections;

public class Resource: namedStat{
    protected int max;


    
    public int Max
    {
        get { return max; }
        protected set { max = value; }
    }
    public override int Current
    {
        get { return current; }
        set
        {
            current = Mathf.Clamp(value, 0, max);
        }
    }
    //constructors
    protected Resource()
    {
        max = 0;
    }

    public Resource(string name)
    {
        this.name = name;
        max = 0;
    }

    //modifiers

    //addResource
    //amount - input amount
    //return - extra amount
    public int addResource(int amount)
    {
        int output = amount + Current - Max;
        if (output < 0) output = 0;
        Current += amount;
        return output;
    }

    public void setMax(int amount)
    {
        Max = amount;
    }

    public int increaseMax(int increase)
    {
        return Max += increase;
    }

}