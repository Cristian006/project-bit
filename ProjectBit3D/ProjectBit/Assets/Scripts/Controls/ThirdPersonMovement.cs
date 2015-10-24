using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ThirdPersonMotor))]
public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;

    Button switchButt;

    private MovementMotor motor;
    private ThirdPersonMotor m;

    //If is AI only use high view camera not third person camera
    [HideInInspector]
    public bool isAI = false;

    public Camera myCam;
    public Camera WorldCam;

    void Awake()
    {
        
    }

    void Start()
    {
        switchButt = GameObject.FindGameObjectWithTag("switchView").GetComponent<Button>();
        WorldCam = GameObject.FindGameObjectWithTag("worldCam").GetComponent<Camera>();
        motor = GetComponent<MovementMotor>();
        m = GetComponent<ThirdPersonMotor>();
        switchButt.onClick.AddListener(() => {
            Switch();
        });
        Debug.Log(GameManager.gm.Mobile());
        isAI = GameManager.gm.Mobile();
        PlayerSetUp();
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
            motor.Velocity = _velocity;

            //Calculate rotation as a 3D vector (turning around)
            float _yRot = Input.GetAxisRaw("Mouse X");

            Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

            //Apply rotation
            m.Rotate(_rotation);

            //Calculate camera rotation as a 3D vector (turning around)
            float _xRot = Input.GetAxisRaw("Mouse Y");

            Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * lookSensitivity;

            //Apply camera rotation
            m.RotateCamera(_cameraRotation);
        }
        
    }

    public void PlayerSetUp()
    {
        if (isAI)
        {
         //   myCam.enabled = true;
            if(myCam.isActiveAndEnabled)
            {
                myCam.gameObject.SetActive(false);
            }
        }
        else
        {
            if(WorldCam.isActiveAndEnabled)
            {
                WorldCam.gameObject.SetActive(false);
            }
        }
    }
    /// <summary>
    /// Switching CameraView
    /// </summary>
    public void Switch()
    {
        if(myCam.gameObject.activeInHierarchy)
        {
            myCam.gameObject.SetActive(false);
            WorldCam.gameObject.SetActive(true);
        }
        else if(WorldCam.gameObject.activeInHierarchy)
        {
            //WorldCam.enabled = !WorldCam.enabled;
            //myCam.enabled = !myCam.enabled;
            WorldCam.gameObject.SetActive(false);
            myCam.gameObject.SetActive(true);
        }
    }
}
