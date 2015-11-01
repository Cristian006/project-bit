using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{
    public Camera myCam;
    public Camera WorldCam;
    // Use this for initialization
    void Start()
    {
        WorldCam = GameObject.FindGameObjectWithTag("worldCam").GetComponent<Camera>();
        myCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        if(GameManager.gm.Mobile())
        {
            Destroy(WorldCam);
        }
        else
        {
            WorldCam.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if(myCam!=null)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Switch();
            }
        }
        else
        {
            WorldCam.gameObject.SetActive(true);   
        }
    }

    public void Switch()
    {
        if (myCam.gameObject.activeInHierarchy)
        {
            myCam.gameObject.SetActive(false);
            WorldCam.gameObject.SetActive(true);
        }
        else if (WorldCam.gameObject.activeInHierarchy)
        {
            WorldCam.gameObject.SetActive(false);
            myCam.gameObject.SetActive(true);
        }
    }
}
