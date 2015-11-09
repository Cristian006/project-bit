using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AI))]
public class Targeting : MonoBehaviour
{
    Transform buildingLayer;
    private Building currentBuilding;

    GameObject target;
    GameObject PlayerMain;

    //AI ai;
    newAI nai;

    public float attackDist;
    public bool searchingForTarget = false;

    private List<GameObject> primaryTargetList;

    public void InIt()
    {
        //REFRENCES
        //ai = GetComponent<AI>();
        nai = GetComponent<newAI>();
        buildingLayer = GameObject.FindGameObjectWithTag("BuildingLayer").transform;
        //PRIMARY TARGETS
        primaryTargetList = new List<GameObject>();

        switch(/*ai.entity.entityType*/ nai.entity.entityType)
        {
            case Entity.EntityType.Player:
                //player ai targeting system
                break;
            case Entity.EntityType.Resource:
                MakePrimaryList(Building.GeneralType.Resource);
                break;
            case Entity.EntityType.Defense:
                MakePrimaryList(Building.GeneralType.Defence);
                break;
            case Entity.EntityType.All:
                FindNearestStructure();
                break;
            case Entity.EntityType.Breacher:
                //FindNearestBlockades();
                break;
            case Entity.EntityType.Troops:
                //FindNearestDefendingUnit();
                break;
        }
    }

    public void MakePrimaryList(Building.GeneralType generalType)
    {
        currentBuilding = null;
        foreach(Transform b in buildingLayer)
        {
            if (b.GetComponent<Building>().generalType == generalType)
            {
                primaryTargetList.Add(b.gameObject);
            }
        }
        
        if(primaryTargetList.Count>0)
        {
            FindNearestPrimaryTarget();
        }
        else
        {
            FindNearestStructure();
        }
    }
    
    //Iterate through primary list, when list is gone, find the closest structure
    public void FindNearestPrimaryTarget()
    {
        GameObject t = null;
        t = FindClosestPrimaryTarget();
        if(t==null)
        {
            FindNearestStructure();
        }
        else
        {
            nai.target = t;
            nai.currentBuilding = t.GetComponent<Building>();
            //ai.AIStart();
        }
    }
    
    //Iterate through the rest of the buildings to find the closest structure.
    void FindNearestStructure()
    {
        GameObject t = null;
        t = FindClosestStructure();
        if (t == null)
        {
            t = GameManager.gm.player;
            if(t==null)
            {
                //BEGIN TO ROAM AROUND
            }
            else
            {
                nai.target = t;
                //ai.AIStart();
            }
        }
        else
        {
            Debug.Log(t.name);
            nai.target = t;
            Debug.Log(nai.target.name);
            nai.currentBuilding = t.GetComponent<Building>();
            //ai.AIStart();
        }

    }

    GameObject FindClosestPrimaryTarget()
    {
        float distance = Mathf.Infinity;
        GameObject closest = null;
        foreach (GameObject b in primaryTargetList)
        {
            currentBuilding = b.GetComponent<Building>();
            if(currentBuilding.health>0)
            {
                Debug.Log("PrimaryBuilding");
                float Dist = Vector3.Distance(transform.position, b.transform.position);
                if (Dist < distance)
                {
                    closest = b;
                    distance = Dist;
                }
            }
        }
        return closest;
    }

    GameObject FindClosestStructure()
    {
        float distance = Mathf.Infinity;
        GameObject closest = null;
        foreach (Transform b in buildingLayer)
        {
            currentBuilding = b.GetComponent<Building>();
            if (currentBuilding.health > 0)                                   //It needs to be if(currentBuilding.health>0) {search} else {continue;}
            {
                Debug.Log("Building");
                float Dist = Vector3.Distance(transform.position, b.transform.position);
                if (Dist < distance)
                {
                    closest = b.gameObject;
                    distance = Dist;
                }
                else
                {
                    continue;
                }
            }
        }
       // Debug.Log(closest.name);
        return closest;
    }

    /*
    /// <summary>
    /// Building Search for the generic troop just finding the closest
    /// </summary>
    /// <returns>Closest GameObject</returns>
    private GameObject FindClosestBuilding()
    {
        GameObject closest = null;                                          //set the gameObject Closest to null as default
        float distance = Mathf.Infinity;
        Vector2 position = transform.position;
        foreach (Transform b in buildingLayer)
        {
            currentBuilding = b.GetComponent<Building>();

            if (currentBuilding.health > 0)                                   //It needs to be if(currentBuilding.health>0) {search} else {continue;}
            {
                Vector2 buildingPos = b.position;
                float curDistance = (buildingPos - position).sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = b.gameObject;                                 //set's the GameObject closest to equal the closest enemy
                    distance = curDistance;                                 //and sets the float variable distance to be the current distance
                    attackDist = currentBuilding.buildingsize;
                }
            }
            else
            {
                continue;       //If the building is dead, continue the iteration but don't exit the loop.
            }
        }

        if (closest == null && PlayerMain.activeInHierarchy)
        {
            return closest = PlayerMain;
        }
        else if (!PlayerMain.activeInHierarchy && closest == null)
        {
            return null;
        }
        else
        {
            return closest;
        }
    }
    */
    /*
    public IEnumerator TargetSearch()
    {
        GameObject searchResult = FindClosestBuilding();
        if (searchResult == null)
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(TargetSearch());
        }
        else
        {
            ai.target = searchResult.transform;
            searchingForTarget = false;
            yield break;
        }
    }
    */
}
