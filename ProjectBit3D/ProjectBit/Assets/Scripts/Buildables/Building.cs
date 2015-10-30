using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class Building : Selectable
{
    public int buildingsize = 3;
    
    public List<Collider> colliders = new List<Collider>();
   // private bool isSelected;
    public string bName;

    Renderer rend;
    Color normal;

    void OnGUI()
    {
        if (selectedState == SelectionState.Selected)
        {
            GUI.Button(new Rect(Screen.width / 2, Screen.height / 20, 100, 30), bName);
        }

    }

    Camera cam;

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
        cam = GameObject.FindGameObjectWithTag("worldCam").GetComponent<Camera>();
    }


    void Update()
    {
        Vector3 CurrentPos = transform.position;
        transform.position = new Vector3(Mathf.RoundToInt(CurrentPos.x), CurrentPos.y, Mathf.RoundToInt(CurrentPos.z));
        
        if(currentBuildingState == BuildingState.Placed)
        {
            ChangeColor(1);
        }
        else if (currentPositionState == PositionState.Possible)
        {
            ChangeColor(2);
        }
        else if (currentPositionState == PositionState.NotPossible)
        {
            ChangeColor(3);
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
        foreach (Transform child in transform)
            changing(child.gameObject, color);
    }

    public void changing(GameObject c, int color)
    {
        switch (color)
        {
            //normal color
            case 1:
                c.GetComponent<Renderer>().material.color = normal;
                break;
            //green
            case 2:
                c.GetComponent<Renderer>().material.color = Color.yellow;
                break;
            //red
            case 3:
                c.GetComponent<Renderer>().material.color = Color.red;
                break;
        }

    }
}
