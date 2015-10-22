using UnityEngine;
using System.Collections;

public class BuildingPlacement : MonoBehaviour
{
	public float scrollSensitivity;
	
	private PlaceableBuilding placeableBuilding;
	private Transform currentBuilding;
	private bool hasPlaced;
	
	public LayerMask buildingsMask;
	
	private PlaceableBuilding placeableBuildingOld;
    
	// Update is called once per frame
	void Update () {
		
		Vector3 m = Input.mousePosition;
		m = new Vector3(m.x,m.y,transform.position.y);
        Vector3 p = GameManager.gm.mousePos;//GetComponent<Camera>().ScreenToWorldPoint(m);

        if (currentBuilding != null && !hasPlaced) {
			
			currentBuilding.position = new Vector3(p.x,0,p.z);
			
			if (Input.GetMouseButtonDown(0))
            {
				if (IsLegalPosition())
                {
					hasPlaced = true;	
				}
			}
		}
		else {
			if (Input.GetMouseButtonDown(0)) {
				RaycastHit hit = new RaycastHit();
				Ray ray = new Ray(new Vector3(p.x,8,p.z), Vector3.down);
				if (Physics.Raycast(ray, out hit,Mathf.Infinity,buildingsMask)) {
					if (placeableBuildingOld != null) {
						placeableBuildingOld.SetSelected(false);
					}
					hit.collider.gameObject.GetComponent<PlaceableBuilding>().SetSelected(true);
					placeableBuildingOld = hit.collider.gameObject.GetComponent<PlaceableBuilding>();
				}
				else {
					if (placeableBuildingOld != null) {
						placeableBuildingOld.SetSelected(false);
					}
				}
			}
		}
	}


	bool IsLegalPosition()
    {
		if (placeableBuilding.colliders.Count > 0)
        {
			return false;	
		}
		return true;
	}
	
	public void SetItem(GameObject b)
    {
		hasPlaced = false;
		currentBuilding = ((GameObject)Instantiate(b)).transform;
		placeableBuilding = currentBuilding.GetComponent<PlaceableBuilding>();
	}
}
