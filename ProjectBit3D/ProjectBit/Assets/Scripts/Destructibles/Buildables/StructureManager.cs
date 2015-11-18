using UnityEngine;

public class StructureManager : MonoBehaviour
{
    //public GameObject[] buildings;
    private BuildingPlacement buildingPlacement;

    public GameObject building;
    public GameObject wall;
    public GameObject defense;
    public GameObject resource;

    // Use this for initialization
    void Awake()
    {
        buildingPlacement = GetComponent<BuildingPlacement>();
    }

    public void Wall()
    {
        buildingPlacement.SetItem(wall);
    }

    public void Defense()
    {
        buildingPlacement.SetItem(defense);
    }

    public void Resource()
    {
        buildingPlacement.SetItem(resource);
    }

    public void Building()
    {
        buildingPlacement.SetItem(building);
    }
}
