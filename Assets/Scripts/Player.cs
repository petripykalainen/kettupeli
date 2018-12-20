using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody rb;
    [SerializeField] public float movementSpeed = 1.0f;
    [SerializeField] float attackTimer = 0.5f;
    public float timer = 0f;
    PlayerHealth health;
    PlayerAttack playerSlasher;
    Vector3 forward, right;
    public Transform camera;
    Animator anim;
    private float OGspeed;
    private float speedTimer;
    private bool speedTimerActive;
    public bool isMoving;

    private TrailRenderer trail;

    // Use this for initialization
    void Start ()
    {
        playerSlasher = GetComponent<PlayerAttack>();
        health = GetComponent<PlayerHealth>();
        anim = GameObject.Find("weasel_final_textured").GetComponent<Animator>();
        //Debug.Log("Playe???  " + player);
        //Debug.Log(weapon.name);
        rb = GetComponentInChildren<Rigidbody>();
        camera = GameObject.Find("PlayerCamera").transform;
        forward = camera.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        OGspeed = movementSpeed;

        trail = gameObject.transform.GetChild(2).GetComponent<TrailRenderer>();
    }


    // Update is called once per frame
    void FixedUpdate ()
    {
        timer += Time.deltaTime;
        isMoving = Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;
        anim.SetBool("isMoving", isMoving);

        if (!health.isDead)
        {
            if (Input.anyKey)
            {
                Move();
                //Debug.Log("Player Move");
            }
            if (Input.GetKeyUp("space") && (timer >= attackTimer))
            {
                if (isMoving)
                {
                    anim.SetTrigger("move_attack_trigger");
                }
                else
                {
                    anim.SetTrigger("attack_trigger");
                }
                timer = 0f;
                playerSlasher.PlaySlashSFX();
            }

            if (speedTimerActive)
            {
                speedTimer -= Time.deltaTime;
                if (speedTimer < 0)
                {
                    movementSpeed = OGspeed;
                    speedTimerActive = false;
                    trail.emitting = false;
                }
            }
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

    public void SpeedBoost(float duration)
    {
        trail.emitting = true;
        speedTimerActive = true;
        speedTimer = duration;
        if (movementSpeed < 20f)
        {
            movementSpeed *= 2;
        }
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
        
        if (heading != Vector3.zero)
        {
            transform.forward = heading;
        }
        transform.position += sideMovement;
        transform.position += upMovement;
    }
}
