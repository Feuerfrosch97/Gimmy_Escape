using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HebelShalter : MonoBehaviour {
    public Animation anim;
    public bool DoorOpen = false;
    public Animation Open;

	
	void Start ()
    {
        anim = GetComponent<Animation>();
        Open = GameObject.Find("Stampfer").GetComponent<Animation>();

    }
	

	void Update ()
    {
		
	}

    void OnTriggerStay(Collider other)
    {
        print("Press C");
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.C) )
            {
            anim.Play(anim.clip.name);
            Debug.Log("focking hell");
            DoorOpen = true;
            Open.Play(Open.clip.name);
            
            }
    }
   
}
