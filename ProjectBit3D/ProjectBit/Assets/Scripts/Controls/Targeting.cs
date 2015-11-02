using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AI))]
public class Targeting : MonoBehaviour
{
    Transform buildingLayer;
    private Building currentBuilding;

    GameObject target;
    GameObject PlayerMain;

    public float attackDist;

    public bool foundTarget;

    public bool searchingForTarget = false;
    float searchTime = 1f;
    float time;

    AI ai;

    void Awake()
    {
        ai = GetComponent<AI>();
        buildingLayer = GameObject.FindGameObjectWithTag("BuildingLayer").transform;
        PlayerMain = GameObject.FindGameObjectWithTag("Player");
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

            if (currentBuilding.gameObject.activeInHierarchy)                                   //It needs to be if(currentBuilding.health>0) {search} else {continue;}
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

        if(closest == null && PlayerMain.activeInHierarchy)
        {
            foundTarget = true;
            return closest = PlayerMain;
        }
        else if(!PlayerMain.activeInHierarchy && closest == null)
        {
            foundTarget = false;
            return null;
        }
        else
        {
            foundTarget = true;
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
