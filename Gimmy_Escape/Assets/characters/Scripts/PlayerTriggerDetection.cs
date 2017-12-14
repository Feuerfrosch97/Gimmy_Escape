using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerDetection : MonoBehaviour {
    public bool PlayerSeen = false;
	// Use this for initialization
	void Start ()
    {
        PlayerSeen = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerSeen = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerSeen = false;
        }
    }
}
