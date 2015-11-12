using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class MovementMotor : MonoBehaviour
{
    Rigidbody rb;
    private Vector3 velocity = Vector3.zero;
    private float rotation = 0f;
    private float maxVelocity;

    public Vector3 Velocity
    {
        get { return velocity; }
        set { velocity += value; }
    }

    public float Rotation
    {
        set { rotation = value; }
        get { return rotation; }
    }

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        //rb.constraints = (RigidbodyConstraints) 80;
    }

    // FixedUpdate is called once per fixed framerate
    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }
    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
            if (velocity.sqrMagnitude > maxVelocity * maxVelocity)
            {
                float newSpeed = (velocity.sqrMagnitude) / 2;
                velocity = Vector3.ClampMagnitude(velocity, Mathf.Sqrt(newSpeed));
            }
        }
    }

    void PerformRotation()
    {
        transform.Rotate(0, rotation, 0);
    }
}
