using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraDrag : MonoBehaviour
{
    // The key we will use for dragging
    public KeyCode dragKey = KeyCode.Mouse0;

    // The ground plane that we will drag along
    // is defined by an origin point and a normal
    public Vector3 groundOrigin = Vector3.zero;
    public Vector3 groundNormal = Vector3.up;

    Plane _groundPlane;
    Vector3 _dragOrigin;

    // We'll save references to the components
    // which we'll need repeatedly
    Camera _camera;
    Transform _transform;


    public void Start()
    {
        // initialisation
        _camera = GetComponent<Camera>();
        _transform = GetComponent<Transform>();
        _groundPlane = new Plane(groundNormal, groundOrigin);
    }

    public void Update()
    {
        //float distanceToIntersection;
        //Ray mouseRay = _camera.ScreenPointToRay(Input.mousePosition);

        
        /*
        // start drag
        if (Input.GetKeyDown(dragKey) && !GameManager.gm.isMouseOnABuilding)
        {
            _groundPlane.Raycast(mouseRay, out distanceToIntersection);
            _dragOrigin = mouseRay.GetPoint(distanceToIntersection);
        }

        // continue drag
        if (Input.GetKey(dragKey) && !GameManager.gm.isMouseOnABuilding)
        {
            _groundPlane.Raycast(mouseRay, out distanceToIntersection);
            Vector3 intersection = mouseRay.GetPoint(distanceToIntersection);
            _transform.position += _dragOrigin - intersection;
        }
        */
    }

    void OnDrawGizmos()
    {
        //Create Collision Box
        //Gizmos.DrawLine(Vector3.zero,new Vector3(10,10,10));
    }
    
}
