using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public GameObject PlayerPrefab;
    [HideInInspector]
    public GameObject player;
    public Transform spawnPoint;

    GridGenerator gg;
    void Awake()
    {
        gm = this;
        gg = GetComponent<GridGenerator>();
        player = (GameObject)Instantiate(PlayerPrefab, spawnPoint.position, spawnPoint.rotation);
    }
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void Random()
    {

    }
}
