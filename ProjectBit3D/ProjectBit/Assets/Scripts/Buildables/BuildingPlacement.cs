using UnityEngine;
using System.Collections;

public class BuildingPlacement : MonoBehaviour
{
    private Structure placeableBuilding;
    private Transform currentBuilding;
    private bool hasPlaced;

    public LayerMask buildingsMask;

    public GameObject BuildingLayer;
    public GameObject WallLayer;

    private Structure placeableBuildingOld;

    // Update is called once per frame
    void Update()
    {
        Vector3 p = GameManager.gm.mousePos;

        if (currentBuilding != null && !hasPlaced)
        {
            currentBuilding.GetComponent<Structure>().currentBuildingState = Structure.BuildingState.Moving;
            currentBuilding.position = new Vector3(Mathf.RoundToInt(p.x), 0, Mathf.RoundToInt(p.z));

            if (Input.GetMouseButtonDown(0))
            {
                if (currentBuilding.GetComponent<Structure>().currentPositionState == Structure.PositionState.Possible)
                {
                    hasPlaced = true;
                    if(currentBuilding.GetComponent<Structure>().generalType == Structure.GeneralType.Blockade)
                    {
                        currentBuilding.SetParent(WallLayer.transform, true);
                    }
                    else
                    {
                        currentBuilding.SetParent(BuildingLayer.transform, true);
                    }
                    currentBuilding.GetComponent<Structure>().currentBuildingState = Structure.BuildingState.Placed;
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit = new RaycastHit();
                Ray ray = new Ray(new Vector3(Mathf.RoundToInt(p.x), 8, Mathf.RoundToInt(p.z)), Vector3.down);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, buildingsMask))
                {
                    if (placeableBuildingOld != null)
                    {
                        placeableBuildingOld.SetSelected(false);
                    }
                    hit.collider.gameObject.GetComponent<Structure>().SetSelected(true);
                    placeableBuildingOld = hit.collider.gameObject.GetComponent<Structure>();
                }
                else
                {
                    if (placeableBuildingOld != null)
                    {
                        placeableBuildingOld.SetSelected(false);
                    }
                }
            }
        }
    }

    public void SetItem(GameObject b)
    {
        hasPlaced = false;
        currentBuilding = ((GameObject)Instantiate(b)).transform;
        placeableBuilding = currentBuilding.GetComponent<Structure>();
    }
}
