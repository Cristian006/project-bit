using UnityEngine;
using System.Collections;

public class SecondaryStat{

    private string _name;
    private int _max;
    private int _current;
    private float _regeneration;


    public string Name { get { return _name; } }

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
                case statContainer.Max: Max = (int)value; break;
                case statContainer.Current: Current = (int)Mathf.Clamp(value, 0, Max); break;
                case statContainer.Regeneration: Regeneration = value; break;
            }
        }
    }



    public int Max
    {
        get { return _max; }
        set { _max = Mathf.FloorToInt(Mathf.Clamp(value, 1, Mathf.Infinity)); }
    }
    public int Current
    {
        get { return _current; }
        set { _current = Mathf.FloorToInt(Mathf.Clamp(value, 0, _max)); }
    }
    public float Regeneration
    {
        get { return _regeneration; }
        set { _regeneration = Mathf.Clamp(value, 0, Mathf.Infinity); }
    }



    public SecondaryStat(string name) {
        this._name = name;
	}
	
	// Update is called once per frame
	void Update () {
        Current += (int) Regeneration;
	}
}
