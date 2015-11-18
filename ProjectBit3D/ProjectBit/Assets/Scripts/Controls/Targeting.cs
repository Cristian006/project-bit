using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(newAI))]
public class Targeting : MonoBehaviour
{
    Transform buildingLayer;
    Transform wallLayer;
    Transform entityUnitLayer;
    
    GameObject target;

    private Structure currentStructure;
    private Entity currentEntity;

    private List<GameObject> primaryTargetList;

    //CASHE A FEW THINGS
    private newAI nai;
    private Destructible.CivilizationType civType;

    public void InIt()
    {
        //THIS GAME OBJECT REFRENCES
        nai = GetComponent<newAI>();
        civType = GetComponent<Destructible>().civType;
        
        //IN GAME SCENE REFRENCES
        buildingLayer = GameObject.FindGameObjectWithTag("BuildingLayer").transform;
        wallLayer = GameObject.FindGameObjectWithTag("WallLayer").transform;
        entityUnitLayer = GameObject.FindGameObjectWithTag("EntityUnitLayer").transform;

        //PRIMARY TARGETS
        primaryTargetList = new List<GameObject>();

        //Initialize Player Targeting System
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

    #region NULL CHECKS AND INITIAL SEARCH CALL
    public void MakePrimaryList(Structure.GeneralType generalType)
    {
        currentStructure = null;
        foreach(Transform b in buildingLayer)
        {
            if (b.GetComponent<Structure>().generalType == generalType && b.GetComponent<Destructible>().civType != civType)
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

    /// <summary>
    ///Iterate through primary list, when list is gone, find the closest structure
    /// </summary>
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
            nai.currentStructure = currentStructure;
            nai.roam = false;
        }
    }

    /// <summary>
    ///Iterate through the rest of the buildings to find the closest structure.
    /// </summary>
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
            nai.currentStructure = currentStructure;
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
            nai.currentStructure = currentStructure;
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
            if(b.GetComponent<Destructible>().civType != civType)
            {
                currentStructure = b.GetComponent<Structure>();
                if (currentStructure.health > 0)
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
        }
        return closest;
    }

    GameObject FindClosestStructure()
    {
        float distance = Mathf.Infinity;
        GameObject closest = null;
        foreach (Transform b in buildingLayer)
        {
            if(b.GetComponent<Destructible>().civType != civType)
            {
                currentStructure = b.GetComponent<Structure>();
                if (currentStructure.health > 0)
                {
                    Debug.Log("Building");
                    float Dist = Vector3.Distance(transform.position, b.position);
                    if (Dist < distance)
                    {
                        closest = b.gameObject;
                        distance = Dist;
                    }
                }
            }
        }
        return closest;
    }

    GameObject FindBlockades()
    {
        float distance = Mathf.Infinity;
        GameObject closest = null;
        foreach (Transform t in wallLayer)
        {
            if(t.GetComponent<Destructible>().civType != civType)
            {
                currentStructure = t.GetComponent<Structure>();
                if (currentStructure.health > 0)
                {
                    float Dist = Vector3.Distance(transform.position, t.position);
                    if (Dist < distance)
                    {
                        closest = t.gameObject;
                        distance = Dist;
                    }
                }
            }
        }
        return closest;
    }

    GameObject FindNearestUnit()
    {
        float distance = Mathf.Infinity;
        GameObject closest = null;
        foreach(Transform e in entityUnitLayer)
        {
            if (e.GetComponent<Destructible>().civType != civType)
            {
                currentEntity = e.GetComponent<Entity>();
                if (currentEntity.health > 0)
                {
                    float Dist = Vector3.Distance(transform.position, e.position);
                    if (Dist < distance)
                    {
                        closest = e.gameObject;
                        distance = Dist;
                    }
                }
            }            
        }
        return closest;
    }
    #endregion
}
