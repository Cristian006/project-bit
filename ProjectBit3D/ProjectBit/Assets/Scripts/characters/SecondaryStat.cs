using UnityEngine;
using System.Collections;

public class SecondaryStat{


    private int _max;
    private float _current;
    private float _regeneration;

    public int Max
    {
        get { return _max; }
        set { _max = Mathf.FloorToInt(Mathf.Clamp(value, 1, Mathf.Infinity)); }
    }
    public float Current
    {
        get { return _current; }
        set { _current = Mathf.Clamp(value, 0, _max); }
    }
    public float Regeneration
    {
        get { return _regeneration; }
        set { _regeneration = Mathf.Clamp(value, 0, Mathf.Infinity); }
    }



    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        Current += Regeneration;
	}
}
