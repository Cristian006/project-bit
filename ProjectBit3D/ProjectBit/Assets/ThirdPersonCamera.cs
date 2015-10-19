using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {

    public GameObject target;
    public float damping = 10f;
    float offset = 5f;
    float height = 2f;
    public Vector3 direction;

    void Start()
    {
        target = GameManager.gm.player;
       // offset = Vector3.Magnitude( transform.position - target.transform.position);
    }

    void LateUpdate()
    {
        direction = new Vector3(Mathf.Sin(Mathf.Deg2Rad*target.transform.rotation.eulerAngles.y),0, Mathf.Cos(Mathf.Deg2Rad * target.transform.rotation.eulerAngles.y));
        direction = -direction / direction.magnitude;
        Vector3 desiredPosition = target.transform.position + direction*offset+Vector3.up*height;
        //Vector3 position = Vector3.Slerp(transform.position, desiredPosition, Time.deltaTime * damping);
        // transform.position = position;
        transform.position = desiredPosition;

        transform.LookAt(target.transform.position);
    }
}

