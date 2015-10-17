using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject grid;
    public GameObject tilePrefab;
    GameObject plane;

    public float width = 10;
    public float height = 10;
    [HideInInspector]
    public bool gridGenerated = false;
    
    void Awake()
    {
        GenerateGrid();
    }

    public void GenerateGrid()
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
}
