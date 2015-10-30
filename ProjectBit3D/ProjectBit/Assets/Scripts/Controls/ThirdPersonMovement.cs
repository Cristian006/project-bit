using UnityEngine;

[RequireComponent(typeof(MovementMotor))]
[RequireComponent(typeof(Attack))]
public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 6f;
    private Attack attack;
    private MovementMotor motor;
    
    void Awake()
    {
        lookSensitivity =  PlayerPrefs.GetFloat("LookSensitivity", 6f);
        attack = GetComponent<Attack>();
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
        float _yRot = Input.GetAxisRaw("Mouse X") * lookSensitivity;

        //Apply rotation
        motor.Rotation = _yRot;

        //INPUT
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            attack.attack();
        }
    }
}
