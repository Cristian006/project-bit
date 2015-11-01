using UnityEngine;
using System.Collections;

public class RegeneratingResource : Resource {

    protected float regeneration;

    //properties
    public float this[string name]
    {
        get {
            switch (name)
            {
                case statContainer.Max: return Max;
                case statContainer.Current: return Current;
                case statContainer.Regeneration: return Regeneration;
            }
            return -1;
        }
        set
        {
            switch (name)
            {
                case statContainer.Max:
                    Max = (int)value;
                    break;
                case statContainer.Current:
                    Current = (int)Mathf.Clamp(value, 0, Max);
                    break;
                case statContainer.Regeneration:
                    Regeneration = value;
                    break;
            }
        }
    }
    
    
    public float Regeneration
    {
        get { return regeneration; }
        set { regeneration =Mathf.Clamp(value, 0, Mathf.Infinity); }
    }


    //constructors 
    public RegeneratingResource(string name) {
        this.name = name;
        regeneration = 0;
    }
	
	// Update is called once per frame
	void Update () {
        Current += (int) Regeneration;//Not sure how to deal with regen
	}
}
