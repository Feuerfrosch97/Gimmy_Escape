using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerStay(Collider other)
    {
        print("Press E");
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            Application.LoadLevel("Hauptmenu");
            Debug.Log("Fuck Ya M8");
            
        }
    }
        
}

