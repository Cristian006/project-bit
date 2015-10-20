using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ThirdPersonMotor))]
public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;

    public Button switchButt;

    private ThirdPersonMotor motor;

    //If is AI only use high view camera not third person camera
    public bool isAI;

    public Camera myCam;
    public Camera WorldCam;

    void Awake()
    {
        switchButt = GameObject.FindGameObjectWithTag("switchView").GetComponent<Button>();
        WorldCam = GameObject.FindGameObjectWithTag("worldCam").GetComponent<Camera>();
      
    }

    void Start()
    {
        motor = GetComponent<ThirdPersonMotor>();
        PlayerSetUp();
        switchButt.onClick.AddListener(() => {
            Switch();
        });
    }

    void Update()
    {
        if(isAI)
        {
            //AI CODE
        }
        else
        {
            //Calculate movement velocity as a 3D vector
            float _xMov = Input.GetAxisRaw("Horizontal");
            float _zMov = Input.GetAxisRaw("Vertical");

            Vector3 _movHorizontal = transform.right * _xMov;
            Vector3 _movVertical = transform.forward * _zMov;

            // Final movement vector
            Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

            //Apply movement
            motor.Move(_velocity);

            //Calculate rotation as a 3D vector (turning around)
            float _yRot = Input.GetAxisRaw("Mouse X");

            Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

            //Apply rotation
            motor.Rotate(_rotation);

            //Calculate camera rotation as a 3D vector (turning around)
            float _xRot = Input.GetAxisRaw("Mouse Y");

            Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * lookSensitivity;

            //Apply camera rotation
            motor.RotateCamera(_cameraRotation);
        }
        
    }

    public void PlayerSetUp()
    {
        if (isAI)
        {
            if(!WorldCam.isActiveAndEnabled)
            {
                WorldCam.enabled = true;
            }
            if(myCam.isActiveAndEnabled)
            {
                myCam.enabled = false;
            }
        }
        else
        {
            if (WorldCam.isActiveAndEnabled)
            {
                WorldCam.enabled = false;
            }
            if (!myCam.isActiveAndEnabled)
            {
                myCam.enabled = true;
            }
        }
    }

    public void Switch()
    {
        if(myCam.isActiveAndEnabled)
        {
            myCam.enabled = !myCam.enabled;
            WorldCam.enabled = !WorldCam.enabled;
        }
        else if(WorldCam.isActiveAndEnabled)
        {
            WorldCam.enabled = !WorldCam.enabled;
            myCam.enabled = !myCam.enabled;
        }
    }
}
