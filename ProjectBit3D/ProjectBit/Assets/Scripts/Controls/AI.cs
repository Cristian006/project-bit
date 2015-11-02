using UnityEngine;
using System.Collections;
using Pathfinding;

[RequireComponent(typeof(Attack))]
[RequireComponent(typeof(Targeting))]
[RequireComponent(typeof(Entity))]
public class AI : MonoBehaviour
{

    // What to chase?
    public Transform target;

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
    private Attack Attack;

    MovementMotor motor;
    Targeting Targeting;
    Entity entity;

    void Awake()
    {
        entity = GetComponent<Entity>();
        Attack = GetComponent<Attack>();
        motor = GetComponent<MovementMotor>();
        Targeting = GetComponent<Targeting>();
        switch (entity.entityType)
        {
            case Entity.EntityType.All:
                if (target == null)
                {
                    if (!Targeting.searchingForTarget)
                    {
                        Targeting.searchingForTarget = true;
                        StartCoroutine(Targeting.TargetSearch());
                    }
                    return;
                }
                break;
        }
    }

    void Start()
    {
        seeker = GetComponent<Seeker>();

        // Start a new path to the target position, return the result to the OnPathComplete method
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine(UpdatePath());
    }

    IEnumerator UpdatePath()
    {
        if (target == null)
        {
            Debug.Log("No target");
            yield break;
        }

        // Start a new path to the target position, return the result to the OnPathComplete method
        seeker.StartPath(transform.position, target.position, OnPathComplete);
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
        if (target == null || !target.gameObject.activeInHierarchy)
        {
            if (!Targeting.searchingForTarget)
            {
                Targeting.searchingForTarget = true;
                StartCoroutine(Targeting.TargetSearch());
            }
            return;
        }

        transform.LookAt(target);

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

        distanceFromTarget = Vector3.Distance(transform.position, target.position);
        if(distanceFromTarget <= attackDist)
        {
            Attack.attack();
        }
    }

}
