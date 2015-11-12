using UnityEngine;

public class BuildingManager : MonoBehaviour
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

    /*
    void OnGUI()
    {
        for (int i = 0; i < buildings.Length; i++)
        {
            if (GUI.Button(new Rect(Screen.width / 20, Screen.height / 15 + Screen.height / 12 * i, 100, 30), buildings[i].name))
            {
                buildingPlacement.SetItem(buildings[i]);
            }
        }
    }
    */
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
