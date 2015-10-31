using UnityEngine;
using System.Collections;

public class SecondaryStat{

    private string name;
    private int _max;
    private int _current;
    private float _regeneration;

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
        this.name = name;
	}
	
	// Update is called once per frame
	void Update () {
        Current += (int) Regeneration;
	}
}
