using UnityEngine;

[RequireComponent(typeof(MovementMotor))]
public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;

  
    private MovementMotor motor;
    
    void Awake()
    {
        
    }

    void Start()
    {
        motor = gameObject.GetComponent<MovementMotor>();
    }

    void Update()
    {
        //Calculate movement velocity as a 3D vector
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _moveStrafe = transform.right * _xMov;
        Vector3 _movForward = transform.forward * _zMov;

        // Final movement vector
        Vector3 _velocity = (_moveStrafe + _movForward).normalized * speed;

        //Apply movement
        motor.Velocity = _velocity;

        //Calculate rotation as a 3D vector (turning around)
        float _yRot = Input.GetAxisRaw("Mouse X");

        //Apply rotation
        motor.Rotation = _yRot;

        
    }

    /// <summary>
    /// Switching CameraView
    /// </summary>

}
