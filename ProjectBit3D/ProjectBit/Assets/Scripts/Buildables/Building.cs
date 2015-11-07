using UnityEngine;
using System.Collections.Generic;

public class Building : Destructible
{
    public int buildingsize = 3;
    
    public List<Collider> colliders = new List<Collider>();
   // private bool isSelected;
    public string bName;

    public GameObject BuildingPlatform;

    Renderer rend;
    Color normal;

    void OnGUI()
    {
        if (selectedState == SelectionState.Selected)
        {
            GUI.Button(new Rect(Screen.width / 2, Screen.height / 20, 100, 30), bName);
        }
    }

    public enum GeneralType
    {
        Building,       //townhall/barracks/buildershuts/civilianbuildings
        Blockade,       //walls
        Defence,        //catepults
        Resource        //resource generator, resource storage
    }

    public enum BuildingType
    {                       //EXAMPLES
        TownHall,           //Heart of the city
        Defense,            //catapults
        Blockade,           //walls
        ResourceGenerator,  //mining building
        ResourceStorage,    //gold storage room
        Barrack,            //Troop storage house
        CivilianHome,       //house
        BuildersHome        //workers house
    }

    /// <summary>
    /// Is the building moving or placed
    /// </summary>
    public enum BuildingState
    {
        Moving,         //Moving / Repositioning
        Placed         //Set on ground             
    }

    /// <summary>
    /// Is the positon possible or not
    /// </summary>
    public enum PositionState
    {
        NotPossible,       //Able to be placed in its current location
        Possible     //Not able to be placed in its current location
    }

    /// <summary>
    /// Is the building currently Selected
    /// </summary>
    public enum SelectionState
    {
        UnSelected,
        Selected
    }

    public GeneralType generalType = new GeneralType();
    public BuildingType buildingType = new BuildingType();
    public PositionState currentPositionState = new PositionState();
    public BuildingState currentBuildingState = new BuildingState();
    public SelectionState selectedState = new SelectionState();

    void Awake()
    {
        rend = GetComponentInChildren<Renderer>();
        normal = rend.material.color;
    }

    void Start()
    {

    }


    void Update()
    {
        Vector3 CurrentPos = transform.position;
        transform.position = new Vector3(Mathf.RoundToInt(CurrentPos.x), CurrentPos.y, Mathf.RoundToInt(CurrentPos.z));


        if(currentBuildingState == BuildingState.Moving)
        {
            CheckState();

            if (currentPositionState == PositionState.Possible)
            {
                Debug.Log("ChangeColortoGreen");
                ChangeColor(2);
            }
            else if (currentPositionState == PositionState.NotPossible)
            {
                Debug.Log("ChangeColortoRed");
                ChangeColor(3);
            }
        }
        else if (currentBuildingState == BuildingState.Placed)
        {

            Debug.Log("ChangeColorToNormal");
            ChangeColor(1);
        }
    }

    public void CheckState()
    {
        if (colliders.Count > 0)
        {
            currentPositionState = PositionState.NotPossible;
        }
        else
        {
            currentPositionState = PositionState.Possible;
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Building")
        {
            colliders.Add(c);
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.tag == "Building")
        {
            colliders.Remove(c);
        }
    }

    public void SetSelected(bool s)
    {
        if (s)
        {
            selectedState = SelectionState.Selected;
        }
        else
        {
            selectedState = SelectionState.UnSelected;
        }
    }

    public void BuildingDestroyed()
    {
        //Destroy Building
    }

    void OnMouseDrag()
    {

    }

    void OnMouseExit()
    {

    }

    public void ChangeColor(int color)
    {
        switch (color)
        {
            //normal color
            case 1:
                BuildingPlatform.SetActive(false);
                break;
            //green
            case 2:
                BuildingPlatform.GetComponent<Renderer>().material.color = Color.green;
                break;
            //red
            case 3:
                BuildingPlatform.GetComponent<Renderer>().material.color = Color.red;
                break;
        }
    }

    public override void Death()
    {
        gameObject.SetActive(false);
    }

}
