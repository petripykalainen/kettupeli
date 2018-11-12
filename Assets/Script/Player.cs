using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {

    Player player;
    Rigidbody rb;
    public float movementSpeed = 3.0f;
    public float sprintAmount = 6.0f;
    public float dashAmount = 20.0f;

    private IEnumerator coroutine;
    const int staminaMaxAmount = 100;
    public int staminaAmount;
    public int staminaDrainAmount = 3;
    public int staminaRegenAmount = 1;
    public float staminaRegenWaitTime = 5.0f;

    public bool staminaInUse = false;
    public bool staminaRegenReady = false;
    public bool staminaRegenCalled = false;

    public bool dashReady = true;
    

    //public float jumpSpeed = 30.0f;
    //public int jumpCount = 0;
    //public int maxJumps = 2;

    // Use this for initialization
    void Start ()
    {
        staminaAmount = staminaMaxAmount;
        player = FindObjectOfType<Player>();
        Debug.Log("Playe???  " + player);
        rb = GetComponentInChildren<Rigidbody>();
        Debug.Log(rb);        
    }
	
	// Update is called once per frame
	void Update ()
    {
        Move();
        ResetSpeed();
    }

    private void Move()
    {
        float usedSpeed = movementSpeed;

        if ( staminaAmount <= 15 && !staminaRegenCalled)
        {
            StartCoroutine(StaminaRegenWait(staminaRegenWaitTime));
            staminaRegenCalled = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) && staminaAmount > 35 && dashReady == true)
        {
            usedSpeed = movementSpeed * dashAmount;
            staminaAmount -= 25 - staminaDrainAmount;
            staminaInUse = true;
            dashReady = false;
            StartCoroutine(DashRegenWait(3.0f));
        }
        
        if (Input.GetKey("space") && staminaAmount > 15)
        {
            usedSpeed = movementSpeed * sprintAmount;
            staminaInUse = true;
        }
        if (Input.GetKey("up"))
        {
            transform.Translate(new Vector3(1, 0, 1) * usedSpeed * Time.deltaTime);
        }
        if (Input.GetKey("right"))
        {
            transform.Translate(new Vector3(1, 0, -1) * usedSpeed * Time.deltaTime);
        }
        if (Input.GetKey("left"))
        {
            transform.Translate(new Vector3(-1, 0, 1) * usedSpeed * Time.deltaTime);
        }
        if (Input.GetKey("down"))
        {
            transform.Translate(new Vector3(-1, 0, -1) * usedSpeed * Time.deltaTime);
        }

        movementSpeed = ResetSpeed();
        if (staminaInUse == true) { staminaAmount -= staminaDrainAmount; }
        else if (staminaRegenReady == true ) { staminaAmount += staminaRegenAmount; }

        if (staminaAmount >= 100)
        {
            staminaAmount = 100;
            staminaRegenReady = false;
        }
        if (staminaInUse == true){ StopCoroutine(StaminaRegenWait(staminaRegenWaitTime));}
        if (staminaInUse == false && staminaAmount != 100) {StartCoroutine(StaminaRegenWait(staminaRegenWaitTime));}
        staminaInUse = false;

        //TODO stamina mittari
        Debug.Log(staminaAmount);
        //if (Input.GetKey("space"))
        //{
        //    Jump();
        //}

    }

    private float ResetSpeed()
    {
        float basicSpeed = movementSpeed;
        return basicSpeed;
    }

    private bool ChangeRegenStatus(bool status) { return !status; }

    private IEnumerator StaminaRegenWait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        staminaRegenReady = true;
        staminaRegenCalled = false;
        print("stam Coroutine ended: " + Time.time + " seconds");
    }

    private IEnumerator DashRegenWait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        dashReady = true;
        print(" dash Coroutine ended: " + Time.time + " seconds");
    }


    //private void Jump()
    //{   
    //    if (rb.velocity.y > -0.01f && rb.velocity.y < 0.01f) { jumpCount = 0; }

    //        if(jumpCount < maxJumps)
    //        {
    //            Debug.Log("Hyppy");
    //            Vector3 jumpUp = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
    //            rb.velocity += jumpUp * Time.deltaTime;
    //            jumpCount += 1;
    //        }
    //}
}
