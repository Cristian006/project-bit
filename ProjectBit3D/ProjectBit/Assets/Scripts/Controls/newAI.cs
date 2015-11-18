using UnityEngine;
using System.Collections;
using Pathfinding;

[RequireComponent(typeof(Targeting))]
public class newAI : MonoBehaviour
{ 
    public GameObject target;
    private Seeker seeker;
    private CharacterController controller;
    private MovementMotor motor;
    private Attack attack;
    private Targeting targeting;
    public Entity entity;
    public Structure currentStructure;
    public float updateRate = 1f;
    public bool canMove = true;
    public float attackDistance = 5f;

    //The calculated path
    public Path path;
    //The AI's speed per second
    public float speed = 10;
    //The max distance from the AI to a waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 3;
    //The waypoint we are currently moving towards
    private int currentWaypoint = 0;
    
    public bool AIOn = true;

    public bool isRoaming = false;
    public bool roam = false;

    public void Awake()
    {
        motor = GetComponent<MovementMotor>();
        seeker = GetComponent<Seeker>();
        entity = GetComponent<Entity>();
        attack = GetComponent<Attack>();
        targeting = GetComponent<Targeting>();
        targeting.InIt();
    }

    public void Start()
    {
        if(target == null)
        {
            if (!isRoaming)
            {
                isRoaming = true;
                seeker.StartPath(transform.position, new Vector3(transform.position.x + (int)Random.Range(-10f, 10f), transform.position.y, transform.position.z + (int)Random.Range(-10f, 10f)), OnPathComplete);
            }
        }
        else
        {
            //Start a new path to the targetPosition, return the result to the OnPathComplete function
            seeker.StartPath(transform.position, target.transform.position, OnPathComplete);
        }
        StartCoroutine(UpdatePath());
    }

    public IEnumerator UpdatePath()
    {
        if (target == null)         //If there is no target, begin to roam
        {
            if (!isRoaming)
            {
                isRoaming = true;
                seeker.StartPath(transform.position, new Vector3(transform.position.x + (int)Random.Range(-10f, 10f), transform.position.y, transform.position.z + (int)Random.Range(-10f, 10f)), OnPathComplete);
            }
        }
        else
        {
            // Start a new path to the target position, return the result to the OnPathComplete method
            seeker.StartPath(transform.position, target.transform.position, OnPathComplete);
        }
        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());
    }

    public void OnPathComplete(Path p)
    {
        Debug.Log("Yay, we got a path back. Did it have an error? " + p.error);
        if (!p.error)
        {
            path = p;
            //Reset the waypoint counter
            currentWaypoint = 0;
        }
    }

    public void Update()
    {
        if (AIOn)
        {
            if (target == null)
            {
                targeting.Begin();
            }
            if (roam)
            {
                canMove = true;
            }
            else if (target != null)
            {
                transform.LookAt(target.transform);
                if (target.GetComponent<Destructible>().health <= 0)
                {
                    target = null;
                    currentStructure = null;
                    return;
                }

                if (Vector3.Distance(transform.position, target.transform.position) <= attackDistance)
                {
                    canMove = false;
                    attack.attack();
                }
                else
                {
                    canMove = true;
                }
            }
            
            if (canMove)
            {
                if (path == null)
                {
                    //We have no path to move after yet
                    return;
                }


                if (currentWaypoint >= path.vectorPath.Count)
                {
                    Debug.Log("End Of Path Reached");
                    if(roam)
                    {
                        if(isRoaming)
                        {
                            isRoaming = false;
                        }
                    }
                    return;
                }

                //Direction to the next waypoint
                Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;

                motor.Velocity = dir * speed;

                //Check if we are close enough to the next waypoint
                //If we are, proceed to follow the next waypoint
                if (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance)
                {
                    currentWaypoint++;
                    return;
                }
            }
        }
    }
}
