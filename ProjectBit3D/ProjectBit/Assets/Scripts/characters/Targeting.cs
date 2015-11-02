using UnityEngine;
public class Targeting : MonoBehaviour
{
    Transform buildingLayer;
    public Entity entity;
    private Building currentBuilding;

    public GameObject target;
    
    void Awake()
    {
        entity = GetComponent<Entity>();
        Debug.Log(entity.entityType);
        buildingLayer = GameObject.FindGameObjectWithTag("BuildingLayer").transform;
        switch (entity.entityType)
        {
            case Entity.EntityType.All:
                target = FindClosestBuilding();
                break;
        }
    }
    
    void Start()
    {
        switch (entity.entityType)
        {
            case Entity.EntityType.All:
                target = FindClosestBuilding();
                break;
        }
    }

    void FixedUpdate()
    {
        switch (entity.entityType)
        {
            case Entity.EntityType.All:
                target = FindClosestBuilding();
                break;
        }
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
            if (b.gameObject.name == "BuildingLayer")
            {
                continue;
            }
            else
            {
                currentBuilding = b.GetComponent<Building>();
            }

            Vector2 buildingPos = b.position;
            float curDistance = (buildingPos - position).sqrMagnitude;
            if (curDistance < distance)
            {
                closest = b.gameObject;                                 //set's the GameObject closest to equal the closest enemy
                distance = curDistance;                                 //and sets the float variable distance to be the current distance
            }

            /*
            if (currentBuilding.health>0)                                   //It needs to be if(currentBuilding.health>0) {search} else {continue;}
            {
                Vector2 buildingPos = b.position;
                float curDistance = (buildingPos - position).sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = b.gameObject;                                 //set's the GameObject closest to equal the closest enemy
                    distance = curDistance;                                 //and sets the float variable distance to be the current distance
                }
            }
            else
            {
                continue;       //If the building is dead, continue the iteration but don't exit the loop.
            }
            */
        }

        if(closest == null)
        {
            return closest = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            return closest;
        }
    }
}
