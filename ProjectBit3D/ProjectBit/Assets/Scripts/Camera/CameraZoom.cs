using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float orthoZoomSpeed = 0.5f;        // The rate of change of the orthographic size in orthographic mode.

    public float zoomMin = 5;
    public float zoomMax = 20;

    Camera worldCam;

    void Awake()
    {
        worldCam = GameObject.FindGameObjectWithTag("worldCam").GetComponent<Camera>();
    }

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        worldCam.orthographicSize = Mathf.Clamp(worldCam.orthographicSize + (Input.GetAxis("Mouse ScrollWheel") != 0 ? Mathf.Sign(Input.GetAxis("Mouse ScrollWheel")) : 0), zoomMin, zoomMax);
#else
        // If there are two touches on the device...
        if (Input.touchCount == 2)
        {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

                // ... change the orthographic size based on the change in distance between the touches.
                worldCam.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;

                // Make sure the orthographic size never drops below zero.
                worldCam.orthographicSize = Mathf.Clamp(worldCam.orthographicSize, 10, 30);// .Max(worldCam.orthographicSize, 0.1f);
        }

#endif
    }
}
