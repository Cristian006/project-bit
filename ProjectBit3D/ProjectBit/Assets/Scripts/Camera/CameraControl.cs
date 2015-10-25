using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour {
    Button switchButt;


    public Camera myCam;
    public Camera WorldCam;
    // Use this for initialization
    void Awake () {

        switchButt = GameObject.FindGameObjectWithTag("switchView").GetComponent<Button>();
        WorldCam = GameObject.FindGameObjectWithTag("worldCam").GetComponent<Camera>();

        switchButt.onClick.AddListener(() => {
            Switch();
        });
    }
	

    public void Switch()
    {
        if (myCam.gameObject.GetComponent<ThirdPersonCamera>().enabled)
        {
            myCam.gameObject.GetComponent<ThirdPersonCamera>().enabled = false;
            WorldCam.gameObject.SetActive(true);
        }
        else if (WorldCam.gameObject.activeInHierarchy)
        {
            myCam.gameObject.GetComponent<ThirdPersonCamera>().enabled = true;
            //WorldCam.enabled = !WorldCam.enabled;
            //myCam.enabled = !myCam.enabled;
            WorldCam.gameObject.SetActive(false);
            myCam.gameObject.SetActive(true);
        }
    }
}
