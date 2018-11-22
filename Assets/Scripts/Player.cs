using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody rb;
    [SerializeField] float movementSpeed = 1.0f;
    Vector3 forward, right;
    public Transform camera;


	// Use this for initialization
	void Start ()
    {
        //Debug.Log("Playe???  " + player);
        //Debug.Log(weapon.name);
        rb = GetComponentInChildren<Rigidbody>();
        //Debug.Log(rb);
        camera = GameObject.Find("PlayerCamera").transform;
        forward = camera.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;



	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (Input.anyKey)
        {
            Move();
        }

        /*
        Vector3 forward = transform.TransformDirection	(Vector3.forward) * 10;
        Debug.DrawRay(
	    transform.position, 
	    forward, 	
    	Color.red);
        Debug.Log("Horizontal: " + Input.GetAxisRaw("Horizontal") + "--- Vertical: " + Input.GetAxisRaw("Vertical"));
        Vector3 move = new Vector3(Input.GetAxisRaw("Vertical"), 0f, Input.GetAxisRaw("Horizontal"));
        transform.Translate(move * movementSpeed * Time.deltaTime);
        */



    }

    private void Move()
    {
        /*if (Input.GetKey("up"))
        {
            transform.Translate(new Vector3(1, 0, 1) * movementSpeed * Time.deltaTime);
            transform.Rotate(Vector3.up, 90f);
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
        */

        //Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        Vector3 sideMovement = right * movementSpeed * Time.deltaTime * Input.GetAxisRaw("Horizontal");
        Vector3 upMovement = forward * movementSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        Vector3 heading = Vector3.Normalize(sideMovement + upMovement);
        Vector3 movement = sideMovement.normalized + upMovement.normalized;
        if (heading != Vector3.zero)
        {
            transform.forward = heading;
        }

        rb.MovePosition(rb.transform.position + movement * movementSpeed * Time.deltaTime);
        //transform.position += sideMovement;
        //transform.position += upMovement;
    }
}
