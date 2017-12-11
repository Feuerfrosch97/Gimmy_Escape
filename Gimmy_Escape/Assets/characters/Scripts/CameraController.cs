using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;

    public float smoothSpeed = 0.12f;
    public Vector3 offset;
    //public Transform TargetForMovement;

    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
        if (GameObject.Find("CameraTurn").GetComponent<CameraTurnRight>().CameraToDoor == true)
        {
            target = GameObject.Find("door_open (3)").GetComponent<Transform>();
            smoothSpeed = 0.05f;
            offset.x = -8f;
            offset.y = 1.39f;
           offset.z = -3.25f;
        }
        else if (GameObject.Find("CameraTurn").GetComponent<CameraTurnRight>().CameraToDoor == false)
        {
            target = GameObject.Find("Player").GetComponent<Transform>();
            smoothSpeed  = 0.125f;
            offset.x = 0f;
            offset.y = 1.39f;
            offset.z = -3.25f;
        }
    }

}