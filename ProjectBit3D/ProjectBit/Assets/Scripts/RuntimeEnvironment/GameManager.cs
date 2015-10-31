using UnityEngine;
using System.Collections;
public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public GameObject PlayerPrefab;

    //public GameObject[,] GridFloor;
    //public GridGenerator gg;

    [HideInInspector]
    public GameObject player;
    public Transform spawnPoint;

    Plane plane = new Plane(Vector3.up, Vector3.zero);

    public Camera worldCam;
    public Vector3 mousePos;

    public bool Mobile()
    {
#if UNITY_EDITOR
        return false;
#elif UNITY_ANDROID || UNITY_IOS
        return true;
#elif UNITY_STANDALONE
        return false;
#else
        return false;
#endif
    }

    private bool mouseIsOverABuilding;

    public bool isMouseOnABuilding
    {
        get { return mouseIsOverABuilding; }
        set { mouseIsOverABuilding = value; }
    }

    void Awake()
    {
        //IF WE NEED THE GRID ARRAY BUT AS OF NOW WE KIND OF DONT.
        //GetComponent<GridGenerator>().GenerateGrid();
        //GridFloor = GetComponent<GridGenerator>().gridArray;
        gm = this;
        player = (GameObject)Instantiate(PlayerPrefab, spawnPoint.position, spawnPoint.rotation);
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = worldCam.ScreenPointToRay(Input.mousePosition);

        float distance = 0;
        if (plane.Raycast(ray, out distance))
        {
            mousePos = ray.GetPoint(distance);
            Debug.DrawRay(ray.origin, ray.direction * distance, Color.green);
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);
        }
    }
}
