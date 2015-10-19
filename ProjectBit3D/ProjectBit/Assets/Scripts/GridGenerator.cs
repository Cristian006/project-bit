using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    //grid
    public GameObject grid;
    //tile prefab
    public GameObject lightTile;
    public GameObject darkTile;
    //refrence plane;
    GameObject plane;

    public int gridsize = 10;

    //Offset to make them spawn at the psoition of the actual grid but I think they are better off staying at 0
    //We'll talk about it later
    /*
    float zoffset = 0.5f;
    float yoffset = -0.5f;
    float xoffset = 0.5f;
    */

    float zoffset = 0;
    float yoffset = -0.5f;
    float xoffset = 0;

    [HideInInspector]
    public bool gridGenerated = false;
    
    void Awake()
    {
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        for (int i = 0; i < gridsize; i++)
        {
            if(i%2==0)
                plane = (GameObject)Instantiate(lightTile, new Vector3(xoffset + i, yoffset, zoffset), Quaternion.identity);
            else
                plane = (GameObject)Instantiate(darkTile, new Vector3(xoffset + i, yoffset, zoffset), Quaternion.identity);
            plane.transform.SetParent(grid.transform);
            for (int j = 1; j < gridsize; j++)
            {
                if (i % 2 == 0)
                {
                    if(j%2==0)
                    {
                        plane = (GameObject)Instantiate(lightTile, new Vector3(xoffset + i, yoffset, zoffset + j), Quaternion.identity);
                    }
                    else 
                    {
                        plane = (GameObject)Instantiate(darkTile, new Vector3(xoffset + i, yoffset, zoffset + j), Quaternion.identity);
                    }
                    plane.transform.SetParent(grid.transform);
                }
                else
                {
                    if (j % 2 == 0)
                    {
                        plane = (GameObject)Instantiate(darkTile, new Vector3(xoffset + i, yoffset, zoffset + j), Quaternion.identity);
                    }
                    else
                    {
                        plane = (GameObject)Instantiate(lightTile, new Vector3(xoffset + i, yoffset, zoffset + j), Quaternion.identity);
                    }
                    plane.transform.SetParent(grid.transform);
                }
            }
            gridGenerated = !gridGenerated;
        }
    }
    /*
    public void GenerateGridOld()
    {
        int x = 0;
        int z = 0;
        for (int i = 0; i < height; i++)
        {
            z = 0;
            plane = (GameObject)Instantiate(tilePrefab, new Vector3(x, 0, z), Quaternion.identity);
            plane.transform.SetParent(grid.transform, true);
            for (int j = 0; j < height; j++)
            {
                z += (int)height;
                plane = (GameObject)Instantiate(tilePrefab, new Vector3(x, 0, z), Quaternion.identity);
                plane.transform.SetParent(grid.transform, true);
            }
            x += (int)width;
        }
        gridGenerated = !gridGenerated;
    }
    */
}
