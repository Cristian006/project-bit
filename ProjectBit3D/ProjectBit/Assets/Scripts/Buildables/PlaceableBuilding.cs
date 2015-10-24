using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlaceableBuilding : MonoBehaviour
{

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

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Building")
        {
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

    void Update()
    {
        Vector3 CurrentPos = transform.position;
        transform.position = new Vector3(Mathf.RoundToInt(CurrentPos.x), CurrentPos.y, Mathf.RoundToInt(CurrentPos.z));
    }

}
