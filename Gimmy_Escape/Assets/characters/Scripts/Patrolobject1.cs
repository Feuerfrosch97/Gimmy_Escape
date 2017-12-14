using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolobject1 : MonoBehaviour
{

    public int Speed;
    public Rigidbody Rb3d;
    public float TurnTime;
    public Animation Turning;
    public Transform Enemy;
    private float x;
    public GameObject PlayerFindCollider;
    //public Transform DetectCollision;



    void Awake()
    {
        Rb3d = gameObject.GetComponent<Rigidbody>();
        StartCoroutine(Move());
        Turning = GameObject.Find("Cameraton").GetComponent<Animation>();
        //GameObject enemy1;
        //EnemyMovement EnemyMovementScript = enemy1.GetComponent<EnemyMovement>();
        //EnemyMovement = GetComponent("EnemyMovement");
        //GameObject.Find("Enemy (1)").GetComponent<EnemyMovement>().walkSpeed;
        //DetectCollision = GameObject.Find("ColliderDetecter").GetComponent<Transform>();
        PlayerFindCollider.GetComponent<Transform>();
    }
    void Update()
    {
        Rb3d.velocity = new Vector3(Speed, Rb3d.velocity.y, 0);
        x = transform.position.x - Enemy.position.x;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && x < 0.00000001f)
        {
            Turning.Play("Turn1");
            Debug.Log("Enemy Collision Detected");
            GameObject.Find("Cameraton").GetComponent<EnemyMovement>().TurnSpeed = 0;
            //DetectCollision.transform.position.x + 3;
            GameObject.Find("CollisionDetector").GetComponent<Transform>().transform.position = new Vector3(transform.position.x, transform.position.y, 3);
        }
        if (other.tag == "Enemy" && x > -0.00000001f)
        {
            Turning["Turn2"].speed = -3f;
            Turning.Play("Turn2");
            Debug.Log("Enemy Collision Detected");
            GameObject.Find("Cameraton)").GetComponent<EnemyMovement>().TurnSpeed = 0;


        }
    }
    IEnumerator Move()
    {

        yield return new WaitForSeconds(TurnTime);
        Speed = -Speed;

        StartCoroutine(Move());

    }
    IEnumerator TurningTime()
    {

        yield return new WaitForSeconds(1);
        GameObject.Find("Cameraton").GetComponent<EnemyMovement>().TurnSpeed = 2;
        Turning.Play("Walk");



    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Cameraton")
        {
            StartCoroutine(TurningTime());
        }
    }

}