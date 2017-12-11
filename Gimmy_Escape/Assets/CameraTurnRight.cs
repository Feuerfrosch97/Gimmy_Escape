using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTurnRight : MonoBehaviour
{
    public Camera MainCamera;
    public bool CameraToDoor = false;





    void Update()
    {


    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            CameraToDoor = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            CameraToDoor = false;
        }
    }
}
