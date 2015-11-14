using UnityEngine;

public class ResourceGenerator : Structure
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
    
    void Awake()
    { 
        stats = new statContainer("Building");
        maxHealth = 100;
        health = 100;
        generalType = GeneralType.Resource;
        buildingType = BuildingType.ResourceGenerator;
    }

    // Use this for initialization
    void Start()
    {
       
    }
}
