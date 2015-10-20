using UnityEngine;
using System.Collections;

public class Selectable : Destructible
{
    public void OnDrag()
    {
        
        transform.position = new Vector3(transform.position.x, 2, transform.position.z);
    }

    void OnMouseEnter()
    {
        Debug.Log("Building");
        // rend.material.color = Color.red;
    }

    void OnMouseOver()
    {
        Debug.Log("Building");
        //  rend.material.color -= new Color(0.1F, 0, 0) * Time.deltaTime;
    }

    void OnMouseDown()
    {
        Debug.Log(gameObject.name);
    }
}
