using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{
    public Camera playerCam;
    public Camera WorldCam;
    // Use this for initialization
    void Start()
    {
        WorldCam = GameObject.FindGameObjectWithTag("worldCam").GetComponent<Camera>();
        playerCam = GameObject.FindGameObjectWithTag("playerCam").GetComponent<Camera>();
        if(GameManager.gm.Mobile())
        {
            GameManager.gm.isInThirdPersonView = false;
            Debug.Log("I am on Mobile");
            Destroy(WorldCam);
        }
        else
        {
            GameManager.gm.isInThirdPersonView = true;
            WorldCam.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if(playerCam!=null)
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
        if (playerCam.gameObject.activeInHierarchy)
        {
            GameManager.gm.isInThirdPersonView = false;
            playerCam.gameObject.SetActive(false);
            WorldCam.gameObject.SetActive(true);
        }
        else if (WorldCam.gameObject.activeInHierarchy)
        {
            GameManager.gm.isInThirdPersonView = true;
            WorldCam.gameObject.SetActive(false);
            playerCam.gameObject.SetActive(true);
        }
    }
}
