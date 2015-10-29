using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    //grid
    public GameObject Grid;

    //tile prefab
    public GameObject lightTile;
    public GameObject darkTile;
    //refrence plane;
    GameObject tile;
    
    float zoffset = 0;
    float yoffset = -0.5f;
    float xoffset = 0;

    [HideInInspector]
    public bool gridGenerated = false;
    bool firstTime = true;

    public int gridsize = 10;
    public GameObject[,] gridArray;
    public void GenerateGrid()
    {
        gridArray = new GameObject[gridsize, gridsize];
        for (int x = 0; x < gridsize; x++)
        {
            if (x % 2 == 0)
                tile = (GameObject)Instantiate(lightTile, new Vector3(xoffset + x, yoffset, zoffset), Quaternion.identity);
            else
                tile = (GameObject)Instantiate(darkTile, new Vector3(xoffset + x, yoffset, zoffset), Quaternion.identity);

            tile.transform.SetParent(Grid.transform);

            gridArray[x, 0] = tile;

            for (int z = 1; z < gridsize; z++)
            {
                if (x % 2 == 0)
                {
                    if (z % 2 == 0)
                    {
                        tile = (GameObject)Instantiate(lightTile, new Vector3(xoffset + x, yoffset, zoffset + z), Quaternion.identity);
                    }
                    else
                    {
                        tile = (GameObject)Instantiate(darkTile, new Vector3(xoffset + x, yoffset, zoffset + z), Quaternion.identity);
                    }
                    tile.transform.SetParent(Grid.transform);
                }
                else
                {
                    if (z % 2 == 0)
                    {
                        tile = (GameObject)Instantiate(darkTile, new Vector3(xoffset + x, yoffset, zoffset + z), Quaternion.identity);
                    }
                    else
                    {
                        tile = (GameObject)Instantiate(lightTile, new Vector3(xoffset + x, yoffset, zoffset + z), Quaternion.identity);
                    }
                    tile.transform.SetParent(Grid.transform);
                }
                gridArray[x, z] = tile;
            }
        }
        tile = null;
        gridGenerated = true;
    }
}
