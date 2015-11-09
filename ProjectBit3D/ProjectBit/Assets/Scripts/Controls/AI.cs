using UnityEngine;
using System.Collections;
using Pathfinding;

[RequireComponent(typeof(Attack))]
[RequireComponent(typeof(Targeting))]
[RequireComponent(typeof(Entity))]
public class AI : MonoBehaviour
{
    // What to chase?
    public GameObject target;
    public Building currentBuilding;

    // How many times each second we will update our path
    public float updateRate = 2f;

    // Caching
    private Seeker seeker;

    //The calculated path
    public Path path;

    //The AI's speed per second
    public float speed = 3f;

    [HideInInspector]
    public bool pathIsEnded = false;

    // The max distance from the AI to a waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 3;

    // The waypoint we are currently moving towards
    private int currentWaypoint = 0;

    private float attackDist = 7f;
    float distanceFromTarget;

    public Entity entity;
    private Attack Attack;
    private MovementMotor motor;
    private Targeting Targeting;
    
    void Awake()
    {
        entity = GetComponent<Entity>();
        Attack = GetComponent<Attack>();
        motor = GetComponent<MovementMotor>();
        seeker = GetComponent<Seeker>();
        Targeting = GetComponent<Targeting>();
        Targeting.InIt();
    }

    void Start()
    {
        if(target == null)
        {
            Debug.Log("NO TARGET");
            return;
        }
        else
        {
            Debug.Log("STARTED PATH");
            // Start a new path to the target position, return the result to the OnPathComplete method
            seeker.StartPath(transform.position, target.transform.position, OnPathComplete);

            StartCoroutine(UpdatePath());
        }

    }

    IEnumerator UpdatePath()
    {
        if (target == null)
        {
            Debug.Log("No target");
            yield break;
        }

        // Start a new path to the target position, return the result to the OnPathComplete method
        seeker.StartPath(transform.position, target.transform.position, OnPathComplete);
        Debug.Log("Start Path");
        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());
    }

    public void OnPathComplete(Path p)
    {
        Debug.Log("We got a path. Did it have an error? " + p.error);
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate()
    {
        if (target == null) { return; }

        if (currentBuilding.health <= 0) { return; }

        transform.LookAt(target.transform);



        if (path == null)
        {
            Debug.Log("Path == null");
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
                return;

            Debug.Log("End of path reached.");
            pathIsEnded = true;
            return;
        }
        pathIsEnded = false;

        //Direction to the next waypoint
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;

        motor.Velocity = dir * speed;

        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);

        if (dist < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }

        distanceFromTarget = Vector3.Distance(transform.position, target.transform.position);
        if(distanceFromTarget <= attackDist)
        {
            Attack.attack();
        }
    }
}
