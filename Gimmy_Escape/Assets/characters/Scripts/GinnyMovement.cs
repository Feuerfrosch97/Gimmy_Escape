using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;


public class GinnyMovement : MonoBehaviour {

    public float moveSpeed = 1;
    public float jumpHeight = 1;
    //public Transform groundCheck;
    public Rigidbody ProtoTraps;
    public Transform PlayerBack;
    public float ZahnräderNeeded = 3;
    public Transform groundCheck;
    //public Text ZahnradDisplay;

    private Rigidbody rb;
    public bool grounded = true;
    public int x;

	void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody>();
	}

    void Update()
    {
        grounded = Physics.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        //ZahnradDisplay.text = ("x" + x);

        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector2(0, jumpHeight));
            //grounded = false;

            //    //this.GetComponent<Animator>().SetBool("Jumping", true);
        }
        //if (this.GetComponent<Rigidbody>().velocity.y < 0.0f)
        //{
        ////    this.GetComponent<Animator>().SetBool("Jumping", false);
        ////    this.GetComponent<Animator>().SetBool("Falling", true);

        //}
        //if (this.GetComponent<Rigidbody>().velocity.y > -0.000000001f &&
        //this.GetComponent<Rigidbody>().velocity.y < 0.000000001f &&
        //this.GetComponent<Animator>().GetBool("Falling") == true)
        {
            //this.GetComponent<Animator>().SetBool("Falling", false);
        }
        //if (this.GetComponent<Rigidbody>().velocity.x > 2)
        //    this.GetComponent<Rigidbody>().velocity = new Vector2(2, this.GetComponent<Rigidbody>().velocity.y);

        //if (this.GetComponent<Rigidbody>().velocity.x < -2)
        //    this.GetComponent<Rigidbody>().velocity = new Vector2(-2, this.GetComponent<Rigidbody>().velocity.y);

        //if (this.GetComponent<Rigidbody>().velocity.y < -5)
        //    this.GetComponent<Rigidbody>().velocity = new Vector2(this.GetComponent<Rigidbody>().velocity.x, -5);
        //Raycasting();

    }
    void FixedUpdate()
    {

        //if (grounded == true)
        //{
        float h = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(h * moveSpeed, rb.velocity.y);
        rb.AddForce((Vector2.right * moveSpeed) * h);
        //}
        if (Input.GetKeyUp(KeyCode.X) && grounded == true && x >= ZahnräderNeeded)

        {
            Rigidbody rocketInstance;
            rocketInstance = Instantiate(ProtoTraps, PlayerBack.position, PlayerBack.rotation) as Rigidbody;
            x = x - 3;
        }
        if (x == -3 && Input.GetKeyDown(KeyCode.X))
        {
            transform.position = new Vector3(-7.35f, -2.87f, 0f);
            x = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Stampfer")
        {
            transform.position = new Vector3(-14.71f, -1.9238f, -0.8f);

        }
        if (other.tag == "Zahnrad")
        {
            Destroy(other.gameObject);
            x = x + 1;
            Debug.Log("Zahnräder " + x);

        }


    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            transform.position = new Vector3(-16.11f, -1.97f, -0.8f);
            //if (col.gameObject.tag == "Ground")
            //{
            //    grounded = true;
            //}
        }

    }
    //void Raycasting()
    //{
    //    Debug.DrawLine(lineStart.position, groundedEnd.position, Color.green);
    //    grounded = Physics2D.Linecast(lineStart.position, groundedEnd.position, 1 << LayerMask.NameToLayer("Ground"));
    //}
}
