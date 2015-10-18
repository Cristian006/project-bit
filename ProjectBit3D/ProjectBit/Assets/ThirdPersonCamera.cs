using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {
    //new comment to make differences so the pull request doesn't go through automatically.  Hope this works
    public GameObject target;
    public float damping = 1;
    Vector3 offset;

    void Start()
    {
        target = GameManager.gm.player;
        offset = transform.position - target.transform.position;
        
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = target.transform.position + offset;
        Vector3 position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);
        transform.position = position;

        transform.LookAt(target.transform.position);
    }
}

