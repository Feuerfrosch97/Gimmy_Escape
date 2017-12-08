using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float Y;
    float Z;
    private Transform X;
    public Transform Player;
    public float walkSpeed = 2;
    public Transform Patrol;
    public Animation Die;
    public Transform Collider;
    public GameObject CollisionDetector;
    public int TurnSpeed;
    public int FollowingDyingSpeed;
    //public Collider collideru;

    // Use this for initialization
    void Start()
    {
        Y = transform.position.y;
        Z = transform.position.z;
        //X = Patrol;
        Die = GetComponent<Animation>();
        //collider = GetComponentInChildren<Collider>();
        TurnSpeed = 2;
        FollowingDyingSpeed = 6;
    }



    void Update()
    {
        //if (GetComponentInChildren<PlayerTriggerDetection>().PlayerSeen == true)
        //{
        //    walkSpeed = FollowingDyingSpeed;
        //    X = Player;
        //    Debug.Log("PlayerSeen");
        //    CollisionDetector.GetComponent<Collider>().enabled = false;
        //}
        //else if (GetComponentInChildren<PlayerTriggerDetection>().PlayerSeen == false)
        //{
        //    X = Patrol;
        //    walkSpeed = TurnSpeed;
        //    CollisionDetector.GetComponent<Collider>().enabled = true;
        //}
        float step = walkSpeed * Time.deltaTime;
        Vector3 TMP = Vector3.MoveTowards(transform.position, X.position, step);
        TMP.y = Y;
        //transform.Translate(new Vector3(Mathf.Lerp(target.position.x, transform.position.x, step), 0,0));
        //transform.Translate(new Vector3(0, 0,1));
        //transform.position = new Vector3(transform.position.x, Y, Z);
        //Debug.Log(new Vector3(Mathf.Lerp(target.position.x, transform.position.x, step), 0, 0).ToString());
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(X.position.x, this.transform.position.y, this.transform.position.z), step);


    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        X = Player;
    //        Debug.Log("Player Found");
    //        walkSpeed = 6;

    //    }
    //    //if (other.gameObject.tag == "PatrolColl") 
    //    //{
    //    //    walkSpeed = 0;
    //    //    Die.Play("Turn");
    //    //    StartCoroutine(Turning());
    //    CollisionDetector.GetComponent<Collider>().enabled = false;

    //    //}

    //}
    //private void OnTriggerExit(Collider other) 
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        X = Patrol;
    //        CollisionDetector.GetComponent<Collider>().enabled = true;
    //    }
    //}
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Shock")
        {
            Die.Play("Die");
            TurnSpeed = 0;
            FollowingDyingSpeed = 0;
            StartCoroutine(Dying());
            Destroy(col.gameObject);
        }
    }
    IEnumerator Dying()
    {
        yield return new WaitForSeconds(2);

        Destroy(this.gameObject);
    }
    IEnumerator Turning()
    {
        yield return new WaitForSeconds(2);

        walkSpeed = 2;

    }

}
