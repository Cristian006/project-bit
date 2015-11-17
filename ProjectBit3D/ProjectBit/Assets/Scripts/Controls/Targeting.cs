using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(newAI))]
public class Targeting : MonoBehaviour
{
    Transform buildingLayer;
    Transform wallLayer;
    Transform entityUnitLayer;
    private Structure currentBuilding;
    private Entity currentEntity;

    GameObject target;
    
    newAI nai;

    public float attackDist;
    public bool searchingForTarget = false;

    private List<GameObject> primaryTargetList;

    public void InIt()
    {
        //REFRENCES
        nai = GetComponent<newAI>();
        buildingLayer = GameObject.FindGameObjectWithTag("BuildingLayer").transform;
        wallLayer = GameObject.FindGameObjectWithTag("WallLayer").transform;
        entityUnitLayer = GameObject.FindGameObjectWithTag("EntityUnitLayer").transform;
        
        //PRIMARY TARGETS
        primaryTargetList = new List<GameObject>();

        Begin();
    }

    public void Begin()
    {
        switch (nai.entity.entityType)
        {
            case Entity.EntityType.Player:
                FindNearestEnemyUnit();
                break;
            case Entity.EntityType.Resource:
                MakePrimaryList(Structure.GeneralType.Resource);
                break;
            case Entity.EntityType.Defense:
                MakePrimaryList(Structure.GeneralType.Defense);
                break;
            case Entity.EntityType.All:
                FindNearestStructure();
                break;
            case Entity.EntityType.Breacher:
                FindNearestBlockade();
                break;
            case Entity.EntityType.Troops:
                FindNearestEnemyUnit();
                break;
        }
    }

    #region NULL CHECKS
    public void MakePrimaryList(Structure.GeneralType generalType)
    {
        currentBuilding = null;
        foreach(Transform b in buildingLayer)
        {
            if (b.GetComponent<Structure>().generalType == generalType)
            {
                primaryTargetList.Add(b.gameObject);
            }
        }
        
        if(primaryTargetList.Count>0)
        {
            //ITERATE THROUGH NEAREST PRIMARY TARGET LIST
            FindNearestPrimaryTarget();
        }
        else
        {
            //GO AFTER THE NEAREST BUILDINGS AFTER NO ITEMS IN LIST
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
            nai.currentStructure = t.GetComponent<Structure>();
            nai.roam = false;
        }
    }
    
    //Iterate through the rest of the buildings to find the closest structure.
    void FindNearestStructure()
    {
        GameObject t = null;
        t = FindClosestStructure();
        if (t == null)
        {
            FindNearestEnemyUnit();
        }
        else
        {
            nai.target = t;
            nai.currentStructure = t.GetComponent<Structure>();
            nai.roam = false;
        }

    }

    public void FindNearestBlockade()
    {
        GameObject t = null;
        t = FindBlockades();
        if (t == null)
        {
            FindNearestEnemyUnit();
        }
        else
        {
            nai.target = t;
            nai.currentStructure = t.GetComponent<Structure>();
            nai.roam = false;
        }
    }

    public void FindNearestEnemyUnit()
    {
        GameObject t = null;
        t = FindNearestUnit();
        if (t == null)
        {
            nai.target = null;
            nai.roam = true;
        }
        else
        {
            nai.target = t;
            nai.roam = false;
        }
    }
    #endregion

    #region PLAYER SEARCH FUNCTIONS
    GameObject FindClosestPrimaryTarget()
    {
        float distance = Mathf.Infinity;
        GameObject closest = null;
        foreach (GameObject b in primaryTargetList)
        {
            currentBuilding = b.GetComponent<Structure>();
            if (currentBuilding.health > 0)
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
            currentBuilding = b.GetComponent<Structure>();
            if (currentBuilding.health > 0)                                   //It needs to be if(currentBuilding.health>0) {search} else {continue;}
            {
                Debug.Log("Building");
                float Dist = Vector3.Distance(transform.position, b.position);
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

    
    GameObject FindNearestUnit()
    {
        float distance = Mathf.Infinity;
        GameObject closest = null;
        //Debug.Log("ATTACKING THE NEAREST UNIT DEFENDERS");
        foreach(Transform t in entityUnitLayer)
        {
            if(t.gameObject.activeInHierarchy)
            {
                Debug.Log("Looking for enemy Unit");
                if (t.GetComponent<Entity>().entityType != GetComponent<Entity>().entityType)
                {
                    currentEntity = t.GetComponent<Entity>();
                    //TODO: This is where we check player ID's
                    //if (currentEntity.PlayerID != nai.entity.PlayerID)
                    //{
                        //Debug.LogError("SHOULD GET ENEMY NOW");
                        float Dist = Vector3.Distance(transform.position, t.position);
                        if (Dist < distance)
                        {
                            closest = t.gameObject;
                            distance = Dist;
                        }
                    //}
                }
            }
            
        }
        return closest;
    }


    GameObject FindBlockades()
    {
        float distance = Mathf.Infinity;
        GameObject closest = null;
        //Debug.Log("ATTACKING THE NEAREST UNIT DEFENDERS");
        foreach (Transform t in wallLayer)
        {
            //Debug.Log("Looking for enemy Unit");
            if (t.GetComponent<Structure>().generalType == Structure.GeneralType.Blockade && t.gameObject.activeInHierarchy)
            {
                currentBuilding = t.GetComponent<Structure>();
                
                //Debug.LogError("SHOULD GET ENEMY NOW");
                float Dist = Vector3.Distance(transform.position, t.position);
                if (Dist < distance)
                {
                    closest = t.gameObject;
                    distance = Dist;
                }
            }
        }
        return closest;
    }
    #endregion

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
