using UnityEditor;
using UnityEngine;

public class GridEditor : EditorWindow
{
    bool groupEnabled;
    bool myBool = true;
    int gridsize = 1;
    int maxGridSize = 1;
    bool GridHasBeenGenerated;

    //tile prefab
    public GameObject lightTile = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/GridTiles/LightTile.prefab", typeof(GameObject));
    public GameObject darkTile = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/GridTiles/DarkTile.prefab", typeof(GameObject));
    public GameObject townHall = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Buildings/TownHall.prefab", typeof(GameObject));
    public GameObject refrenceObject;
   
    float zoffset = 0;
    float yoffset = -0.5f;
    float xoffset = 0;
    public GameObject Grid;

    public GameManager gm;

    public GameObject[,] gridArray;

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
        gm = (GameManager)EditorGUILayout.ObjectField("GameManager", gm, typeof(GameManager), true);
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
        gridArray = new GameObject[gridsize, gridsize];
        if(!GridHasBeenGenerated)
        {
            for (int x = 0; x < gridsize; x++)
            {
                if (x % 2 == 0)
                {
                    refrenceObject = (GameObject)PrefabUtility.InstantiatePrefab(lightTile);
                    refrenceObject.transform.position = new Vector3(xoffset + x, yoffset, zoffset);
                    refrenceObject.transform.rotation = Quaternion.identity;
                    //tile = (GameObject)Instantiate(lightTile, new Vector3(xoffset + x, yoffset, zoffset), Quaternion.identity);
                }
                else
                {
                    refrenceObject = (GameObject)PrefabUtility.InstantiatePrefab(darkTile);
                    refrenceObject.transform.position = new Vector3(xoffset + x, yoffset, zoffset);
                    refrenceObject.transform.rotation = Quaternion.identity;
                    //tile = (GameObject)Instantiate(darkTile, new Vector3(xoffset + x, yoffset, zoffset), Quaternion.identity);
                }

                refrenceObject.transform.SetParent(Grid.transform);

                gridArray[x, 0] = refrenceObject;

                for (int z = 1; z < gridsize; z++)
                {
                    if (x % 2 == 0)
                    {
                        if (z % 2 == 0)
                        {
                            refrenceObject = (GameObject)PrefabUtility.InstantiatePrefab(lightTile);
                            refrenceObject.transform.position = new Vector3(xoffset + x, yoffset, zoffset + z);
                            refrenceObject.transform.rotation = Quaternion.identity;
                            //tile = (GameObject)Instantiate(lightTile, new Vector3(xoffset + x, yoffset, zoffset + z), Quaternion.identity);
                        }
                        else
                        {
                            refrenceObject = (GameObject)PrefabUtility.InstantiatePrefab(darkTile);
                            refrenceObject.transform.position = new Vector3(xoffset + x, yoffset, zoffset + z);
                            refrenceObject.transform.rotation = Quaternion.identity;
                        }
                        refrenceObject.transform.SetParent(Grid.transform);
                    }
                    else
                    {
                        if (z % 2 == 0)
                        {
                            //tile = (GameObject)Instantiate(darkTile, new Vector3(xoffset + x, yoffset, zoffset + z), Quaternion.identity);
                            refrenceObject = (GameObject)PrefabUtility.InstantiatePrefab(darkTile);
                            refrenceObject.transform.position = new Vector3(xoffset + x, yoffset, zoffset + z);
                            refrenceObject.transform.rotation = Quaternion.identity;
                        }

                        else
                        {
                            // tile = (GameObject)Instantiate(lightTile, new Vector3(xoffset + x, yoffset, zoffset + z), Quaternion.identity);
                            refrenceObject = (GameObject)PrefabUtility.InstantiatePrefab(lightTile);
                            refrenceObject.transform.position = new Vector3(xoffset + x, yoffset, zoffset + z);
                            refrenceObject.transform.rotation = Quaternion.identity;
                        }
                        refrenceObject.transform.SetParent(Grid.transform);
                    }
                    gridArray[x, z] = refrenceObject;
                }
                Debug.Log(gridArray.Length);
            }
            GridHasBeenGenerated = true;
            gm.GridFloor = gridArray;
                        
     //       GenerateStructures();
            
        }
    }

    /*
    public void GenerateStructures()
    {
        refrenceObject = (GameObject)PrefabUtility.InstantiatePrefab(townHall);
        Vector3 townHallPos = gridArray[Random.Range(10, 20), Random.Range(20, 30)].transform.position;
        //ADDING IN THE 0.5 YOFFSET TO POSITION ABOVE THE ACTUAL COORDINATES
        refrenceObject.transform.position = new Vector3(townHallPos.x, townHallPos.y + Mathf.Abs(yoffset), townHallPos.z);
    }
    */
}
