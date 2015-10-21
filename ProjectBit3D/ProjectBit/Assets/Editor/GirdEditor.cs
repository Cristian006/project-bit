using UnityEditor;
using UnityEngine;

public class GridEditor : EditorWindow
{
    string myString = "Grid Name";
    bool groupEnabled;
    bool myBool = true;
    int gridsize = 1;
    int maxGridSize = 1;
    bool GridHasBeenGenerated;

    //tile prefab
    public GameObject lightTile = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/GridTiles/LightTile.prefab", typeof(GameObject));
    public GameObject darkTile = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/GridTiles/DarkTile.prefab", typeof(GameObject));
    public GameObject tile;
    public static GameObject[,] gridArray = new GameObject[50,50];
    float zoffset = 0;
    float yoffset = -0.5f;
    float xoffset = 0;
    public GameObject Grid;

    // Add menu item named "My Window" to the Window menu
    [MenuItem("Window/Grid Editor")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(GridEditor));
    }

    void OnGUI()
    {
        GUILayout.Label("Grid Settings", EditorStyles.boldLabel);
        myString = EditorGUILayout.TextField("Grid Name", myString);
        maxGridSize = EditorGUILayout.IntField("Max Grid Size", maxGridSize);
        Grid = (GameObject)EditorGUILayout.ObjectField("Grid", Grid, typeof(GameObject), true);
        gridsize = (int)EditorGUILayout.Slider("Grid Size", gridsize, 1, maxGridSize);
        if (GUILayout.Button("Generate Grid"))
        {
            GenerateGrid();
        }
    }

    public void GenerateGrid()
    {
        if(!GridHasBeenGenerated)
        {
            for (int x = 0; x < gridsize; x++)
            {
                if (x % 2 == 0)
                {
                    tile = (GameObject)PrefabUtility.InstantiatePrefab(lightTile);
                    tile.transform.position = new Vector3(xoffset + x, yoffset, zoffset);
                    tile.transform.rotation = Quaternion.identity;
                    //tile = (GameObject)Instantiate(lightTile, new Vector3(xoffset + x, yoffset, zoffset), Quaternion.identity);
                }
                else
                {
                    tile = (GameObject)PrefabUtility.InstantiatePrefab(darkTile);
                    tile.transform.position = new Vector3(xoffset + x, yoffset, zoffset);
                    tile.transform.rotation = Quaternion.identity;
                    //tile = (GameObject)Instantiate(darkTile, new Vector3(xoffset + x, yoffset, zoffset), Quaternion.identity);
                }

                tile.transform.SetParent(Grid.transform);

                gridArray[x, 0] = tile;

                for (int z = 1; z < gridsize; z++)
                {
                    if (x % 2 == 0)
                    {
                        if (z % 2 == 0)
                        {
                            tile = (GameObject)PrefabUtility.InstantiatePrefab(lightTile);
                            tile.transform.position = new Vector3(xoffset + x, yoffset, zoffset + z);
                            tile.transform.rotation = Quaternion.identity;
                            //tile = (GameObject)Instantiate(lightTile, new Vector3(xoffset + x, yoffset, zoffset + z), Quaternion.identity);
                        }
                        else
                        {
                            tile = (GameObject)PrefabUtility.InstantiatePrefab(darkTile);
                            tile.transform.position = new Vector3(xoffset + x, yoffset, zoffset + z);
                            tile.transform.rotation = Quaternion.identity;
                        }
                        tile.transform.SetParent(Grid.transform);
                    }
                    else
                    {
                        if (z % 2 == 0)
                        {
                            //tile = (GameObject)Instantiate(darkTile, new Vector3(xoffset + x, yoffset, zoffset + z), Quaternion.identity);
                            tile = (GameObject)PrefabUtility.InstantiatePrefab(darkTile);
                            tile.transform.position = new Vector3(xoffset + x, yoffset, zoffset + z);
                            tile.transform.rotation = Quaternion.identity;
                        }

                        else
                        {
                            // tile = (GameObject)Instantiate(lightTile, new Vector3(xoffset + x, yoffset, zoffset + z), Quaternion.identity);
                            tile = (GameObject)PrefabUtility.InstantiatePrefab(lightTile);
                            tile.transform.position = new Vector3(xoffset + x, yoffset, zoffset + z);
                            tile.transform.rotation = Quaternion.identity;
                        }
                        tile.transform.SetParent(Grid.transform);
                    }
                    gridArray[x, z] = tile;
                }
            }
            GridHasBeenGenerated = true;
        }
    }
}
