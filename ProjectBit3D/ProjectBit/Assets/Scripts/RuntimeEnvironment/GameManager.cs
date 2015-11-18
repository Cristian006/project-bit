using UnityEngine;
using System.Collections;
public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public GameObject PlayerPrefab;

    [HideInInspector]
    public GameObject player;
    public Transform spawnPoint;

    public Transform entityUnitLayer;

    Plane plane = new Plane(Vector3.up, Vector3.zero);

    public Camera worldCam;
    public Vector3 mousePos;

    private bool ThirdPersonView;

    public bool isInThirdPersonView
    {
        get { return ThirdPersonView; }
        set { ThirdPersonView = value; }
    }

    public bool Mobile()
    {
#if UNITY_ANDROID || UNITY_IOS
        return true;
#else
        return false;
#endif
    }
    
    private bool firstLoad;
    bool isFirstLoad
    {
        get { return firstLoad; }
        set { firstLoad = value; }
    }

    void OnEnable()
    {
        Load();
    }

    void OnDisable()
    {
        Save();
    }

    void Awake()
    {
        gm = this;
        if(firstLoad)
        {
            InitialGameSetUp();
        }
        player = (GameObject)Instantiate(PlayerPrefab, spawnPoint.position, spawnPoint.rotation);
        player.transform.SetParent(entityUnitLayer,true);
    }

   
    void Start()
    {
        
    }

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

    void InitialGameSetUp()
    {
        firstLoad = true;
        //INSTANTIATE EVERYTHING SET UP EVERYTHING
        //THEN - SAVE
        Save();
    }

    /// <summary>
    /// HUGE LOAD FUNCTION
    /// PURPOSE: Load Everything for the town
    /// </summary>
    void Load()
    {
        
    }

    /// <summary>
    /// HUGE SAVE FUNCTION
    /// PURPOSE: Save Everything in the town
    /// </summary>
    void Save()
    {
        
    }
}
