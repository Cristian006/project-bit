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

    AI ai;

    public float attackDist;
    public bool searchingForTarget = false;

    private List<GameObject> primaryTargetList;

    public void InIt()
    {
        //REFRENCES
        ai = GetComponent<AI>();
        buildingLayer = GameObject.FindGameObjectWithTag("BuildingLayer").transform;
        //PRIMARY TARGETS
        primaryTargetList = new List<GameObject>();

        switch(ai.entity.entityType)
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
    
    void FindNearestPrimaryTarget()
    {
        GameObject t = null;
        t = FindClosestPrimaryTarget();
        if(t==null)
        {
            FindNearestStructure();
        }
        else
        {
            ai.target = t.transform;
        }
    }

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
                ai.target = t.transform;
            }
        }

    }

    GameObject FindClosestPrimaryTarget()
    {
        return null;
    }

    GameObject FindClosestStructure()
    {
        return null;
    }

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
            /* if (b.gameObject.name == "BuildingLayer")
             {
                 Debug.LogWarning("ParentFound");
                 continue;
             }
             else
             {
                 Debug.LogWarning("ActualBuildingFound");

             }
             */
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
}
