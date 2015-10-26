using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Building : Selectable
{
    public int buildingsize = 3;

    [HideInInspector]
    public List<Collider> colliders = new List<Collider>();
    private bool isSelected;
    public string bName;

    void OnGUI()
    {
        if (isSelected)
        {
            GUI.Button(new Rect(Screen.width / 2, Screen.height / 20, 100, 30), bName);
        }

    }

    Camera cam;

    public enum BuildingState
    {
        Placed,         //Set on ground
        Moving          //Moving / Repositioning
    }

    public enum PositionState
    {
        Possible,       //Able to be placed in its current location
        NotPossible     //Not able to be placed in its current location
    }


    PositionState currentPosition = new PositionState();
    BuildingState currentState = new BuildingState();

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("worldCam").GetComponent<Camera>();
        // rend = GetComponent<Renderer>();
    }


    void Update()
    {
        Vector3 CurrentPos = transform.position;
        transform.position = new Vector3(Mathf.RoundToInt(CurrentPos.x), CurrentPos.y, Mathf.RoundToInt(CurrentPos.z));
    }

    public void CheckState()
    {
        if (currentState == BuildingState.Moving)
        {
            /*
            *   check if tile bellow is free to go on
            *
            *   if tiles is free to go on, change building tiles to green;
            *   else if tiles are not free to go on, change building tiles to red;
            *
            */
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Building")
        {
            Destroy(c.gameObject);
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
        isSelected = s;
    }

    public void BuildingDestroyed()
    {
        //Destroy Building
    }


    void OnMouseDrag()
    {
        transform.position = GameManager.gm.mousePos;//new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y, cam.ScreenToWorldPoint(Input.mousePosition).z);
    }
    void OnMouseExit()
    {
        // rend.material.color = Color.white;
    }
    

}
