﻿using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour {
    public Button switchButt;


    public Camera myCam;
    public Camera WorldCam;
    // Use this for initialization
    void Start() {

        switchButt = GameObject.FindGameObjectWithTag("switchView").GetComponent<Button>();
        WorldCam = GameObject.FindGameObjectWithTag("worldCam").GetComponent<Camera>();
        myCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        switchButt.onClick.AddListener(() => {
            Switch();
        });
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
            //WorldCam.enabled = !WorldCam.enabled;
            //myCam.enabled = !myCam.enabled;
            WorldCam.gameObject.SetActive(false);
            myCam.gameObject.SetActive(true);
        }
    }
}
