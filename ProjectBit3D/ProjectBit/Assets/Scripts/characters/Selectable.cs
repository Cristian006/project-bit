using UnityEngine;
using System.Collections;

public class Selectable : Destructible
{

    void OnMouseDrag()
    {
        transform.position = new Vector3(GameManager.gm.mousePos.x, transform.position.y, GameManager.gm.mousePos.z);
        GameManager.gm.isMouseOnABuilding = true;
    }

    void OnMouseEnter()
    {
        Debug.Log("Building");
        // rend.material.color = Color.red;
        GameManager.gm.isMouseOnABuilding = true;
    }

    void OnMouseOver()
    {
        Debug.Log("Building");
        //  rend.material.color -= new Color(0.1F, 0, 0) * Time.deltaTime;
        GameManager.gm.isMouseOnABuilding = true;
    }

    void OnMouseDown()
    {
        Debug.Log(gameObject.name);
        GameManager.gm.isMouseOnABuilding = true;
    }

    void OnMouseExit()
    {
        GameManager.gm.isMouseOnABuilding = false;

    }
}
