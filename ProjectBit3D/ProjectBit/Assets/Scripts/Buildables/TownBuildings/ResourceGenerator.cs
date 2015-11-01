using UnityEngine;
using System.Collections;

public class ResourceGenerator : Building
{
    private string type;//resource name
    private RegeneratingResource resource;


    public string Type //says what type of resource this building makes
    {
        get { return type; }
    }

    public float Amount //say how many resources are in the building
    {
        get { return Mathf.Floor(resource.Current); }
    }



    public int emptyBuilding()
    {
        int current = Mathf.FloorToInt(resource.Current);
        resource.Current -= current;
        return current;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
