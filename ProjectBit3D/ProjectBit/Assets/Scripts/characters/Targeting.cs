using UnityEngine;
using System.Collections;

public class Targeting : MonoBehaviour
{
    Transform buildingLayer;
    public Entity entity;
    
    void Awake()
    {
        entity = GetComponent<Entity>();
        Debug.Log(entity.entityType);
        buildingLayer = GameObject.FindGameObjectWithTag("BuildingLayer").transform;
    }
    
    /// <summary>
    /// Building Search
    /// </summary>
    /// <returns></returns>
    private GameObject FindClosestTarget()
    {
        foreach (Transform b in buildingLayer)
        {
             //Filter and search :)
        }
        return null;
    }
}
