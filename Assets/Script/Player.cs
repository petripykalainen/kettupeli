using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Player player;
    Rigidbody rb;
    public float movementSpeed = 3.0f;
    public float jumpSpeed = 10.0f;


	// Use this for initialization
	void Start ()
    {
        player = FindObjectOfType<Player>();
        Debug.Log("Playe???  " + player);
        rb = GetComponentInChildren<Rigidbody>();
        Debug.Log(rb);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();
        Jump();

        /*
        Vector3 forward = transform.TransformDirection	(Vector3.forward) * 10;
        Debug.DrawRay(
	    transform.position, 
	    forward, 	
    	Color.red);
        Debug.Log("Horizontal: " + Input.GetAxis("Horizontal") + "--- Vertical: " + Input.GetAxis("Vertical"));
        Vector3 move = new Vector3(Input.GetAxis("Vertical"), 0f, Input.GetAxis("Horizontal"));
        transform.Translate(move * movementSpeed * Time.deltaTime);
        */



    }

    private void Move()
    {
        if (Input.GetKey("up"))
        {
            transform.Translate(new Vector3(1, 0, 1) * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey("right"))
        {
            transform.Translate(new Vector3(1, 0, -1) * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey("left"))
        {
            transform.Translate(new Vector3(-1, 0, 1) * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey("down"))
        {
            transform.Translate(new Vector3(-1, 0, -1) * movementSpeed * Time.deltaTime);
        }
    }

    private void Jump()
    {
        if(Input.GetKey("space"))
        {
            Debug.Log("Hyppy");
            Vector3 jumpUp = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
            rb.velocity += jumpUp * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
