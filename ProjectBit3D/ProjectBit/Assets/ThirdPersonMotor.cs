using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ThirdPersonMotor : MonoBehaviour
{
    Rigidbody rb;
    private Vector3 velocity = Vector3.zero;
    private float rotation = 0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start () {
	
	}
    // Gets a movement vector
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    // Gets a rotational vector
    public void Rotate(float _rotation)
    {
        rotation = _rotation;
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        PerformMovement();
        PerformRotation();
    }

    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    void PerformRotation()
    {
        transform.Rotate(0, rotation, 0);
    }
}
