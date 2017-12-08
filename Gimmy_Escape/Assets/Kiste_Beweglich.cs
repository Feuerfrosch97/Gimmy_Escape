using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiste_Beweglich : MonoBehaviour {
    public Transform Player;
    private Transform X;
	void Start ()
    {
        Player = GameObject.Find("Player").GetComponent<Transform>();
        X = Player;
    }
	void Update ()
    {
		
	}
    void OnTriggerStay(Collider other)
    {
        if(other.tag  == "Player" && Input.GetKey(KeyCode.E))
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(X.position.x, this.transform.position.y, this.transform.position.z), GameObject.Find("Player").GetComponent<GinnyMovement>().moveSpeed);
        }
    }
}
