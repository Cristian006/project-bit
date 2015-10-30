using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(Attack))]
public class AI : MonoBehaviour
{

    //The point to move to
    public Transform targetPosition;
    private Seeker seeker;
    private CharacterController controller;
    //The calculated path
    public Path path;
    //The AI's speed per second
    public float speed = 10;
    //The max distance from the AI to a waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 3;
    //The waypoint we are currently moving towards
    private int currentWaypoint = 0;

    private float attackDist = 3f;
    float distance;
    private Attack attack;

    MovementMotor motor;
    void Awake()
    {
        attack = GetComponent<Attack>();
    }
    public void Start()
    {
        motor = GetComponent<MovementMotor>();
        seeker = GetComponent<Seeker>();
        //controller = GetComponent<CharacterController>();
        targetPosition = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log(targetPosition.position);
        //Start a new path to the targetPosition, return the result to the OnPathComplete function
        seeker.StartPath(transform.position, targetPosition.position, OnPathComplete);
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

        transform.LookAt(targetPosition);
        if (path == null)
        {
            //We have no path to move after yet
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            Debug.Log("End Of Path Reached");
            return;
        }
        //Direction to the next waypoint
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        //dir *= speed * Time.deltaTime;
        //controller.SimpleMove(dir);
        motor.Velocity = dir*speed;

        //Check if we are close enough to the next waypoint
        //If we are, proceed to follow the next waypoint
        if (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }

        if(Vector3.Distance(transform.position, targetPosition.position) <= attackDist)
        {
            attack.attack();
        }
    }

}
