using UnityEngine;


[RequireComponent(typeof(ThirdPersonMotor))]
public class ThirdPersonMovement : MonoBehaviour {
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float turningSpeed = 60;

    Rigidbody rb;


    private ThirdPersonMotor motor;
    
    // Use this for initialization
    void Awake () {
        rb = GetComponent<Rigidbody>();
        motor = GetComponent<ThirdPersonMotor>();
    }
	
	// Update is called once per frame
	void Update () {
        
        float _xMov = Input.GetAxisRaw("Horizontal");   //-1 or 1
        float _zMov = Input.GetAxisRaw("Vertical");     //-1 or 1

        float turn = _xMov * turningSpeed * Time.fixedDeltaTime;

        Vector3 _movVertical = transform.forward * _zMov;

        // Final movement vector
        Vector3 _velocity = (_movVertical).normalized * speed;
        
        //Apply movement
        motor.Move(_velocity);
        //Apply Rotation
        motor.Rotate(turn);
    }
}
