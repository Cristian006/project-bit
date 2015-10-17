using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {

    public GameObject target;
    public float damping = 1;
    float offset;

    void Start()
    {
        target = GameManager.gm.player;
        offset = Vector3.Magnitude( transform.position - target.transform.position);
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = target.transform.position + target.transform.rotation.eulerAngles*offset/Vector3.Magnitude(target.transform.rotation.eulerAngles);
        desiredPosition.y = target.transform.position.y + 10;
        Vector3 position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);
        transform.position = position;

        transform.LookAt(target.transform.position);
    }
}

